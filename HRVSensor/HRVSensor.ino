using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using UnityEngine;

public class HRCollector : MonoBehaviour
{
    public double heartRate = 0;
    public double sigmoidHeartRate = 0;
    public int IBI = 0;
    public bool isHeartRate = true;

    SerialPort sp = new SerialPort("\\\\.\\COM3", 9600);

    void Start()
    {
        sp.Open();
        // sp.ReadTimeout = 500;
    }

    // Update is called once per frame
    void Update()
    {

        if(sp.IsOpen)
        {
            // incomingData = int.Parse(sp.ReadLine());
            //we are sending 1 at a time
            if (isHeartRate)
            {
                //ADD TRY CATCH FUNCTIONS
                sigmoidHeartRate = Convert.ToDouble(sp.ReadLine());
                //sigmoidHeartRate = float.Parse(sp.ReadLine());
                Debug.Log(sigmoidHeartRate);
                Debug.Log(heartRate);
                heartRate = Convert.ToDouble(sp.ReadLine());
                isHeartRate = false;
            } else
            {
                IBI = int.Parse(sp.ReadLine());
                Debug.Log("IBI" + IBI);
                isHeartRate = true;
            }

            
        }

    }
}
