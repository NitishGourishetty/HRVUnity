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


                this.transform.localPosition = new Vector3(
                position.x + Mathf.Cos(Time.time + Mathf.Cos(Time.time * Mathf.PI * (float) sigmoidHeartRate)),
                position.y + Mathf.Sin(Time.time * Mathf.PI * 1),
                position.z);
            }
            else
            {
                IBI = int.Parse(sp.ReadLine());
                Debug.Log("IBI" + IBI);
                isHeartRate = true;

                //this.transform.localPosition = new Vector3(
               // position.x + Mathf.Cos(Time.time + Mathf.Cos(Time.time * Mathf.PI * IBI / 800),
                //position.y + Mathf.Sin(Time.time * Mathf.PI * speedY),
                //position.z);
            }

        }

    }
}
