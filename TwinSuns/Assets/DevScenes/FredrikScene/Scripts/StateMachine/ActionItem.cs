using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem 
{
    public enum InputAction { Jump, Attack, Dash, Interact, Enchant};
    public InputAction action;
    [HideInInspector] public float timestamp;

    //Putting settings like these in a scriptable object for backend settings
    //public static float TimeBeforeActionExpire = .3f;

    //Constructor
    public ActionItem(InputAction ia, float stamp)
    {
        action = ia;
        timestamp = stamp;
    }

    //Returns true if action hasn't expired due to timestamp

    public bool CheckIfValid(float expire)
    {
        bool returnValue = false;

        if (timestamp + expire >= Time.time)
        {
            returnValue = true;
        }
        return returnValue;
    }
}
