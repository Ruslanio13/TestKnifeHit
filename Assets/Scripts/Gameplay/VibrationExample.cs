using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VibrationExample : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Vibration.Init();
    }

    public void TapVibrate()
    {
        Vibration.Vibrate();
    }

    public void TapVibrateCustom()
    {
        Vibration.Vibrate(2);
    }

    public void TapCancelVibrate()
    {

        Vibration.Cancel();
    }

    public void TapPopVibrate()
    {
        Vibration.VibratePop();
    }

    public void TapPeekVibrate()
    {
        Vibration.VibratePeek();
    }

    public void TapNopeVibrate()
    {
        Vibration.VibrateNope();
    }
}