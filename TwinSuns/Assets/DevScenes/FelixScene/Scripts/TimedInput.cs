using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedInput
{
    public string ofType;
    public float timed;

    public TimedInput(string type, float time)
    {
        ofType = type;
        timed = time;
    }

}
