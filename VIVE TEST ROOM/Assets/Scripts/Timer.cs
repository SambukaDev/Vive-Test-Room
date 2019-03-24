using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Timer : MonoBehaviour {

    [HideInInspector] public bool Start = false;
    [HideInInspector] public bool Stop = false;
    public String User = "User1";

    private int time;
    private int secs;
    private int mins;
    private int hours;
    private bool IsRecording = true;

    public Manager TheManager;


    private void Update()
    {
        if (Start)
        {
            StartCoroutine("TimerThread");
            Start = false;
        }


        if (Stop)
        {
            RecordTime();
            Stop = false;
        }
    }


    private IEnumerator TimerThread()
    {
        while (IsRecording)
        {
            yield return new WaitForSeconds(1);

            time += 1;
            secs = time % 60;
            mins = (time / 60) % 60;
            hours = (time / 3600) % 24;

            Debug.Log(hours.ToString() + ":" + mins.ToString() + ":" + secs.ToString());
        }
    }


    private void RecordTime()
    {
        //Write time to file
        IsRecording = false;

        string CurMethod = TheManager.ActiveMethod.ToString();

        string FinalTime = hours.ToString() + ":" + mins.ToString() + ":" + secs.ToString();

        // Write the string to a file.
        System.IO.StreamWriter file = new System.IO.StreamWriter("UserTimes.txt", true);

        // Compose a string that consists of three lines.
        string lines = User + ": " + FinalTime + " (Method: " + CurMethod + ")";
        file.WriteLine(lines);

        file.Close();

        //"First line.\r\nSecond line.\r\nThird line."
    }


    //private void Update()
    //{
    //    if (TimerStarted)
    //    {
    //        CurTime = Time.delta - StartTime;
    //    }
    //    Debug.Log(CurTime.ToString());
    //}
}
