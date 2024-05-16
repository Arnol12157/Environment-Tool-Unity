using System;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private const string ENVIRONMENT_PLAYERPREF_KEY = "Environment";
    private const string ENVIRONMENTS_DIRECTORY_PATH = "ProjectConfig/Environments/";
    
    private Environment _currentEnvironment;
    public Environment Environment => _currentEnvironment;

    private void Awake()
    {
        string envName = PlayerPrefs.GetString(ENVIRONMENT_PLAYERPREF_KEY, "");
        _currentEnvironment = ((EnvironmentSO)Resources.Load(ENVIRONMENTS_DIRECTORY_PATH + envName)).EnvironmentInfo;
    }
}