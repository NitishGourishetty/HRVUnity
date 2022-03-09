using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using UnityEngine;

public class HRCollector : MonoBehaviour
{
    public int incomingData = 0;

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
            incomingData = int.Parse(sp.ReadLine());
            Debug.Log(incomingData);

        }

    }
}
