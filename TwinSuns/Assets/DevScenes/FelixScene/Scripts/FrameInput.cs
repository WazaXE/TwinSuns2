using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FrameInput
{
    //public BackendSettingsObject settingsObject;

    /**
    public FrameInput(float x, float y, bool sprintHold, bool dashPress, bool jumpPress, bool jumpRelease)
    {
        this.x = x;
        this.y = y;
        this.sprintHold = sprintHold;
        this.dashPress = dashPress;
        this.jumpPress = jumpPress;
        this.jumpRelease = jumpRelease;
    }
    **/

    public FrameInput(float x, float y, bool sprintHold, bool dashPress)
    {
        this.x = x;
        this.y = y;
        this.sprintHold = sprintHold;
        this.dashPress = dashPress;
    }

    public float x;
    public float y;
    public bool sprintHold;
    public bool dashPress;
    //public bool jumpPress;
    //public bool jumpRelease;

    public class TimedInput
    {
        private bool input = false;
        public float timed;

        public TimedInput(float time)
        {
            timed = time;
        }

    }
}
