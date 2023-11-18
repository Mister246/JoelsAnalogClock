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
//
// Degrees of rotation per second = 0.008333333
// CurrentTimeInSeconds * 0.008333333 = Degrees of rotation for the current time.
//
// IF CurrentTimeInSeconds > 43,200 seconds
//      CurrentTimeInSeconds -= 43,200 seconds
//      Assuming rotation greater than 360 degrees is a problem, this may be needed.
//
// GameObjects need to be rotated on the Z axis.
//
// Degrees should be made negative, as positive rotations are counter-clockwise.

public class AnalogClockScript : MonoBehaviour
{
    Image hourHand;
    Image minuteHand;
    Image secondHand;
    GameObject pivotPoint;

    void Start()
    {
        Debug.Log(DateTime.Now.TimeOfDay.TotalSeconds / 86400);

        hourHand = GameObject.Find("HourHand").GetComponent<Image>();
        // minuteHand = GameObject.Find("MinuteHand").GetComponent<Image>();
        // secondHand = GameObject.Find("SecondHand").GetComponent<Image>();

        pivotPoint = GameObject.Find("PivotPoint");

        // hourHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -(5400f * 0.008333333f)); // 1:30 AM, 45 degrees
        // hourHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -(10800f * 0.008333333f)); // 3:00 AM, 90 degrees
        // hourHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -(21600f * 0.008333333f)); // 6:00 AM, 180 degrees

        hourHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -GetDegreesOfRotation());
    }

    void Update()
    {
        // Debug.Log(GetDegreesOfRotation());
        // hourHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, GetDegreesOfRotation());
    }

    static public float GetDegreesOfRotation()
    {
        return (float)DateTime.Now.TimeOfDay.TotalSeconds * 0.008333333f;
    }
}