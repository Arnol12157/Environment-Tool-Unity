using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Environment", menuName = "TG Utils/Environment Manager/Create Environment", order = 0)]
[Serializable]
public class EnvironmentSO : ScriptableObject
{
    public Environment EnvironmentInfo;
}
