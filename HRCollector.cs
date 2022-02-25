using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using UnityEngine;

public class HRCollector : MonoBehaviour
{
    //This would only work on a windows laptop, else I would need to buy uduino
    SerialPort arduino = new SerialPort("/path", 9600); //9600 bits per second
    public String incomingData;
    public int HeartRate = -1;
    public volatile int IBI = -1;


    // Start is called before the first frame update
    void Start()
    {
        arduino.Open();
        //arduino.ReadTimeout = 1; //adjust
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            //B is heart Rate, and Q is Interbeat interval
            incomingData = arduino.ReadLine();
            var values = incomingData.Split('B', 'Q');
            Debug.Log(incomingData);
            int tmpHR = HeartRate;
            int.TryParse(values[0], out tmpHR); //parses value to String
            HeartRate = tmpHR;
            //parse inter-beat interval
            int tmpIBI = IBI;
            int.TryParse(values[1], out tmpIBI); //parses value to String
            IBI = tmpIBI;
        }
        catch (System.Exception)
        {

        }
    }
}
