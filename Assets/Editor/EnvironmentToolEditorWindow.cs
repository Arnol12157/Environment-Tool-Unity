using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EnvironmentToolEditorWindow : EditorWindow
{
    private const string ENV_NAME_ALREADY_USED_NOTIFICATION =
        "This environment name is already used, write another one";
    private const string CANT_DELETE_USED_ENV_NOTIFICATION =
        "This environment is currently used, set another one first to delete this";
    
    private const string ENVIRONMENTS_DIRECTORY_PATH = "Assets/Resources/ProjectConfig/Environments/";

    private const string ENVIRONMENT_PLAYERPREF_KEY = "Environment";
    private const string SELECTED_ENV_INDEX_PLAYERPREF_KEY = "EnvironmentSelectedIndex";

    private int _selectedEnvIndex = 0;
    private List<string> _optionsList = new();
    private string _oldEnv;
    private string _newEnvNameText = "";

    private Editor _soEditor;

    [MenuItem("TG Utils/Environment Tool")]
    private static void Init()
    {
        EnvironmentToolEditorWindow window = GetWindow<EnvironmentToolEditorWindow>();
        window.titleContent.text = "Environment Tool";
        window.Show();
    }

    private void Awake()
    {
        _selectedEnvIndex = PlayerPrefs.GetInt(SELECTED_ENV_INDEX_PLAYERPREF_KEY, 0);
    }

    private void OnGUI()
    {
        string currentEnvironmentName = GetCurrentEnvironmentName();
        ShowCurrentEnvironment();
        EditorGUILayout.Space();
        CreateNewEnvButton();
        EditorGUILayout.Space();
        ShowAllEnvironmentsInDropdown();
        ShowSetEnvButton();
        EditorGUILayout.Space();

        var environment = GetSelectedEnvironmentInfo();

        if (environment != null && environment.EnvironmentInfo.Name != _oldEnv)
        {
            _soEditor = Editor.CreateEditor(environment);
            _oldEnv = environment.EnvironmentInfo.Name;
        }
        
        if (environment != null && _soEditor != null)
        {
            _soEditor.OnInspectorGUI();
        }
        
        DeleteEnvButton();

        void ShowCurrentEnvironment()
        {
            EditorGUILayout.LabelField("CURRENT ENVIRONMENT: " + currentEnvironmentName);
        }

        void ShowAllEnvironmentsInDropdown()
        {
            string[] files =
                Directory.GetFiles(ENVIRONMENTS_DIRECTORY_PATH, "*.asset", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                var envSO = AssetDatabase.LoadAssetAtPath(file, typeof(EnvironmentSO));
                if (envSO != null && !_optionsList.Contains(envSO.name))
                {
                    _optionsList.Add(envSO.name);
                }
            }

            if (_optionsList.Count > 0)
            {
                _selectedEnvIndex = EditorGUILayout.Popup("Select: ", _selectedEnvIndex, _optionsList.ToArray());
            }
        }

        void ShowSetEnvButton()
        {
            if (_optionsList.Count > 0 && GUILayout.Button("Set Environment"))
            {
                PlayerPrefs.SetInt(SELECTED_ENV_INDEX_PLAYERPREF_KEY, _selectedEnvIndex);
                string filePath = ENVIRONMENTS_DIRECTORY_PATH + _optionsList[_selectedEnvIndex] + ".asset";
                PlayerPrefs.SetString(ENVIRONMENT_PLAYERPREF_KEY,
                    AssetDatabase.LoadAssetAtPath(filePath, typeof(EnvironmentSO)).name);
            }
        }

        void CreateNewEnvButton()
        {
            _newEnvNameText = EditorGUILayout.TextField("New environment name: ", _newEnvNameText);
            if (GUILayout.Button("Create"))
            {
                bool canCreate = (_optionsList.Count > 0 && !_optionsList.Contains(_newEnvNameText)) ||
                                 _optionsList.Count == 0;
                if (canCreate)
                {
                    EnvironmentSO newEnv = ScriptableObject.CreateInstance<EnvironmentSO>();
                    newEnv.EnvironmentInfo.Name = _newEnvNameText;
                    AssetDatabase.CreateAsset(newEnv, ENVIRONMENTS_DIRECTORY_PATH + _newEnvNameText + ".asset");
                    AssetDatabase.SaveAssets();
                    EditorUtility.FocusProjectWindow();
                    Selection.activeObject = newEnv;
                }
                else
                {
                    this.ShowNotification(new GUIContent(ENV_NAME_ALREADY_USED_NOTIFICATION), 2);
                }
            }
        }
        
        void DeleteEnvButton()
        {
            if (_optionsList.Count > 0 && GUILayout.Button("Delete"))
            {
                if (GetCurrentEnvironmentName() != _optionsList[_selectedEnvIndex])
                {
                    string filePath = ENVIRONMENTS_DIRECTORY_PATH + _optionsList[_selectedEnvIndex] + ".asset";
                    AssetDatabase.DeleteAsset(filePath);
                    _optionsList.Clear();
                    _selectedEnvIndex = 0;
                }
                else
                {
                    this.ShowNotification(new GUIContent(CANT_DELETE_USED_ENV_NOTIFICATION), 2);
                }
            }
        }
    }

    private string GetCurrentEnvironmentName()
    {
        return PlayerPrefs.GetString(ENVIRONMENT_PLAYERPREF_KEY, "");
    }

    private EnvironmentSO GetSelectedEnvironmentInfo()
    {
        if (_optionsList.Count == 0)
        {
            return null;
        }
        string filePath = ENVIRONMENTS_DIRECTORY_PATH + _optionsList[_selectedEnvIndex] + ".asset";
        return AssetDatabase.LoadAssetAtPath(filePath, typeof(EnvironmentSO)) as EnvironmentSO;
    }
}