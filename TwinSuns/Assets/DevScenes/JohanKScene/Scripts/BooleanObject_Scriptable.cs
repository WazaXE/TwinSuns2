using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BooleanObject", menuName = "Scriptable Objects/BooleanObject")]
[Serializable]
public class BooleanObject_Scriptable : ScriptableObject
{
    public bool boolean;
}
