using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BackendSettingsObject", order = 2)]
public class BackendSettingsObject : ScriptableObject
{
    public float buffering = 0.2f;
}