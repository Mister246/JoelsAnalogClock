using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Notes about time:
// A full day is 86,400 seconds.
// A full hour is 3600 seconds.
// 
// Hour hand time table:
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
// Degrees of rotation per second = 0.008333333 degrees
// CurrentTimeInSeconds * 0.008333333 = Degrees of rotation for hour hand.
//
// Minute hand time table:
// 0 seconds        = 0 degrees
// 900 seconds      = 90 degrees
// 
// Degrees of rotation per second = 0.1 degrees
// CurrentTimeInSeconds * 0.1 = Degrees of rotation for minute hand.
// 
// Second hand time table:
// 0 seconds        = 0 degrees
// 15 seconds       = 90 degrees
// 
// Degrees of rotation per second = 6 degrees
// CurrentTimeInSeconds * 6 = Degrees of rotation for second hand.
//
// GameObjects need to be rotated on the Z axis.
//
// Degrees of rotation should be made negative, as positive rotations are counter-clockwise.

public class AnalogClockScript : MonoBehaviour
{
    Image hourHand;
    static string hourHandName = "HourHand";
    const float hourHandSecondToDegreesRatio = 0.008333333f;
    // Represents how many degrees per second the hour hand rotates.

    Image minuteHand;
    static string minuteHandName = "MinuteHand";
    const float minuteHandSecondToDegreesRatio = 0.1f;
    // Represents how many degrees per second the minute hand rotates.

    Image secondHand;
    static string secondHandName = "SecondHand";
    const float secondHandSecondToDegreesRatio = 6f;
    // Represents how many degrees per second the second hand rotates.

    GameObject pivotPoint;
    static string pivotPointName = "PivotPoint";

    void Start()
    {
        Debug.Log(DateTime.Now.TimeOfDay.TotalSeconds / 86400);

        hourHand = GameObject.Find(hourHandName).GetComponent<Image>();
        minuteHand = GameObject.Find(minuteHandName).GetComponent<Image>();
        secondHand = GameObject.Find(secondHandName).GetComponent<Image>();
        pivotPoint = GameObject.Find(pivotPointName);

        hourHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -GetDegreesOfRotation(hourHand));
        minuteHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -GetDegreesOfRotation(minuteHand));
        secondHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, -GetDegreesOfRotation(secondHand));
    }

    void Update()
    {
        // Debug.Log(GetDegreesOfRotation());
        // hourHand.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, GetDegreesOfRotation());
    }

    static public float GetDegreesOfRotation(Image hand)
    // Returns the degrees of rotation of the hand given for the current time.
    {
        if (hand.name == hourHandName)
        // IF given the hour hand.
        {
            return (float)DateTime.Now.TimeOfDay.TotalSeconds * hourHandSecondToDegreesRatio;
        }
        else if (hand.name == minuteHandName)
        // IF given the minute hand.
        {
            return (float)DateTime.Now.TimeOfDay.TotalSeconds * minuteHandSecondToDegreesRatio;
        }
        else if (hand.name == secondHandName)
        // IF given the second hand.
        {
            return (float)DateTime.Now.TimeOfDay.TotalSeconds * secondHandSecondToDegreesRatio;
        }

        // If reached this point, something has gone wrong.
        Debug.Log("ERROR: Unable to calculate degrees of rotation. Are the clock hands named correctly?");
        return 0f;
    }
}