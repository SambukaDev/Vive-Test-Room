using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerZone : MonoBehaviour {

    private Timer TheTimer;
    private bool Started = false;
    private bool Stopped = false;

    private void Start()
    {
        TheTimer = GetComponentInParent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(name == "Start Zone" && Started == false)
        {
            TheTimer.Start = true;
            Started = true;
        }
        else if (name == "End Zone" && Stopped == false)
        {
            TheTimer.Stop = true;
            Stopped = true;
        }
    }
}
