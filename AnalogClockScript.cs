using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Notes about time:
// A full day is 86,400 seconds.
// A full hour is 3600 seconds.
// 
// 0 seconds        = 0 degrees
// 5400 seconds     = 45 degrees
// 10,800 seconds   = 90 degrees
// 21,600 seconds   = 180 degrees
// 32,400 seconds   = 270 degrees
// 43,200 seconds   = 360 degrees / 0 degrees
// 54,000 seconds   = 90 degrees
// 64,800 seconds   = 180 degrees
// 75,600 seconds   = 270 degrees
// 86,400 seconds   = 360 degrees / 0 degrees

public class AnalogClockScript : MonoBehaviour
{
    TimeSpan time;
    Image hourHand;
    Image minuteHand;
    Image secondHand;
    GameObject pivotPoint;

    void Start()
    {
        time = DateTime.Now.TimeOfDay;
        Debug.Log(DateTime.Now.TimeOfDay.TotalSeconds / 86400);

        hourHand = GameObject.Find("HourHand").GetComponent<Image>();
        minuteHand = GameObject.Find("MinuteHand").GetComponent<Image>();
        secondHand = GameObject.Find("SecondHand").GetComponent<Image>();

        pivotPoint = GameObject.Find("PivotPoint");
    }

    void Update()
    {
        
    }
}
