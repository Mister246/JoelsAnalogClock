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
// 10,800 seconds   = 90 degrees
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

    float currentTime;

    void Start()
    {
        Application.runInBackground = true;
        Screen.SetResolution(1220, 700, FullScreenMode.Windowed, 144);

        currentTime = (float)DateTime.Now.TimeOfDay.TotalSeconds;

        hourHand = GameObject.Find(hourHandName).GetComponent<Image>();
        minuteHand = GameObject.Find(minuteHandName).GetComponent<Image>();
        secondHand = GameObject.Find(secondHandName).GetComponent<Image>();
    }

    void FixedUpdate()
    {
        currentTime = (float)DateTime.Now.TimeOfDay.TotalSeconds;

        hourHand.transform.rotation = Quaternion.Euler(0f, 0f, -GetDegreesOfRotation(hourHand, currentTime) + 90f);
        minuteHand.transform.rotation = Quaternion.Euler(0f, 0f, -GetDegreesOfRotation(minuteHand, currentTime) + 90f);
        secondHand.transform.rotation = Quaternion.Euler(0f, 0f, -GetDegreesOfRotation(secondHand, currentTime) + 90f);
        // All rotations are offset by 90 degrees due to all three hand's starting position. 
    }

    static public float GetDegreesOfRotation(Image hand, float currentTime)
    // Returns the degrees of rotation of the hand given for the current time.
    // Degrees of rotation returned are between 0 and 360. 
    {
        if (hand.name == hourHandName)
        // IF given the hour hand.
        {
            return currentTime * hourHandSecondToDegreesRatio % 360f;
        }
        else if (hand.name == minuteHandName)
        // IF given the minute hand.
        {
            return currentTime * minuteHandSecondToDegreesRatio % 360f;
        }
        else if (hand.name == secondHandName)
        // IF given the second hand.
        {
            return currentTime * secondHandSecondToDegreesRatio % 360f;
        }

        // If reached this point, something has gone wrong.
        Debug.Log("ERROR: Unable to calculate degrees of rotation. Are the clock hands named correctly?");
        return 0f;
    }
}