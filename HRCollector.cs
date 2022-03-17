using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using UnityEngine;

public class HRCollector : MonoBehaviour
{
    public int heartRate = 0;
    public int IBI = 0;
    public bool isHeartRate = true;
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

        if(sp.IsOpen)
        {
            // incomingData = int.Parse(sp.ReadLine());
            //we are sending 1 at a time
            if (isHeartRate)
            {
                heartRate = int.Parse(sp.ReadLine());
                Debug.Log("heart rate" + heartRate);
                isHeartRate = false;
                
                
                this.transform.localPosition = new Vector3(
                position.x + Mathf.Cos(Time.time + Mathf.Cos(Time.time * Mathf.PI * heartRate),
                position.y + Mathf.Sin(Time.time * Mathf.PI * speedY),
                position.z);
            } else
            {
                IBI = int.Parse(sp.ReadLine());
                Debug.Log("IBI" + IBI);
                isHeartRate = true;
                
                this.transform.localPosition = new Vector3(
                position.x + Mathf.Cos(Time.time + Mathf.Cos(Time.time * Mathf.PI * IBI/800),
                position.y + Mathf.Sin(Time.time * Mathf.PI * speedY),
                position.z);
            }
            
        }

    }
}
