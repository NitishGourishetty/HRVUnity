using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using System.IO.Ports;
using UnityEngine;

public class HRCollector : MonoBehaviour
{
    public static double heartRate = 0;
    public static double sigmoidHeartRate = 0;
    public static double sigmoidIBI = 0.5;
    public static int IBI = 0;
    public static bool isHeartRate = true;
    public Vector3 position;

    SerialPort sp = new SerialPort("\\\\.\\COM3", 9600);

    void Start()
    {
        sp.Open();
        // sp.ReadTimeout = 500;
    }

    // Update is called once per frame
    void Update()
    {
        //Add try catches here btw bub
        if (sp.IsOpen)
        {
            // incomingData = int.Parse(sp.ReadLine());
            //we are sending 1 at a time
            if (isHeartRate)
            {
                sigmoidHeartRate = Convert.ToDouble(sp.ReadLine());
                Debug.Log(sigmoidHeartRate);
                heartRate = Convert.ToDouble(sp.ReadLine());
                Debug.Log(heartRate);
                isHeartRate = false;

            }
            else
            {
                IBI = int.Parse(sp.ReadLine());
                Debug.Log("IBI" + IBI);
                isHeartRate = true;

            }

        }

    }
}
