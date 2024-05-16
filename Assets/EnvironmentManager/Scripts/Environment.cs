using System.Collections.Generic;

[System.Serializable]
public struct Environment
{
    public string Name;
    public List<EnvironmentField> Fields;
}

[System.Serializable]
public struct EnvironmentField
{
    public string Key;
    public string Value;
}