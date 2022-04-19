# UnityBioFeedbackTesting
Getting data from Arduino into Unity Serial Ports

- [Setting up the Arduino and Pulse Sensor with Bluetooth](#setting-up-the-arduino-and-pulse-sensor-with-bluetooth)
- [Reading values in Unity](#reading-values-in-unity)
- [Particle Systems in Unity](#particle-systems-in-unity)

## Setting up the Arduino and Pulse Sensor with Bluetooth

Items necessary:

- Arduino Uno (any model is fine)
- USB B cable
- HC-05 Bluetooth Module
- Pulse Sensor

Step 1: Connect Arduino to Computer containing Arduino IDE and HRVSensor.ino using a USB B cable

Step 2: Connect the Pulse Sensor to the Arduino (black wire to Ground, red wire to 3.3V power, and purple wire to A0 - Analog Input 0)

Step 3: Verify and Upload the [`HRVSensor.ino`](../main/HRVSensor/HRVSensor.ino) sketch to the Arduino Uno (make sure to select the correct COM port under Tools

Step 4: Open Serial Monitor (or Serial Plotter) to view the heart rate readings

Step 5: Disconnect Arduino from the Computer

Step 6: Connect the Bluetooth Module to the Arduino

- RX on HC-05 connects to TX on Arduino
- TX on HC-05 connects to RX on Arduino
- GND (ground) on HC-05 connects to GND on Arduino
- VCC (power) on HC-05 connects to 5V on Arduino

Step 7: Connect the Arduino UNO to an external power source (either a portable power bank or a power outlet)

Step 8: Connect to Bluetooth from the computer
- Open Bluetooth Preferences and connect a device named "HC-05". The password is 1234.

Step 9: Select the COM port in Arduino IDE
- On a Windows, go to Bluetooth Settings (click on more options in Settings>Bluetooth)
- Click on the tab COM ports
- Use the COM port that is "Outgoing" and has the name "HC-05 'Dev B'"
- Select the above COM port (with the correct #!) in the Arduino IDE under Tools>Port
<img width="481" alt="Screen_Shot_2022-04-12_at_10 47 57_PM" src="https://user-images.githubusercontent.com/77863500/164112826-fd9279b9-97cb-414e-8829-5555168a3843.png">

Step 10: Open Serial Monitor and see the values transmitted through Bluetooth!

## Reading values in Unity

[`HRCollector.cs`](../main/HRCollector.cs) contains code to open and listen to the Serial Port 9600 (default + recommended for Bluetooth) in Unity. 

- Create a new object in Unity.

- Click on the object, and in the Inspector tab, add a component called as New script. Title the script `HRCollector`. Add the code from [`HRCollector.cs`](../main/HRCollector.cs). 

- In the script, change the COM port to the one used earlier in the Arduino Sketch when reading via Bluetooth. 
  
  line 16: `SerialPort sp = new SerialPort("\\.\COM3", 9600);`

  ###### Windows format: \\.\COM<#>
  ###### Mac format: /dev/tty.HC-05-DevB
 
This script contains public static variables (essentially global variables) so that other scripts can access the values. Other scripts can access the variables by `HRCollector.<variable_name>`

  For example,

  In `HRCollector.cs`
  
    public static int heartRate;

  `RandomAwesomeObject.cs` accesses the variable through the class HRCollector
  
    myfunc(HRCollector.heartRate);
    
## Particle Systems in Unity
- Create a new object in Unity
- Click on the object, and under Inspector, add a component called as **Particle System**
- You can change the color, texture, size, etc of the particles under properties for the Particle System in the Inspector. 
- In order to manipulate the parameters of the newly created Particle System through code, reference the awesome documentation [here](https://docs.unity3d.com/ScriptReference/ParticleSystem.html). 
[`RandomVariability.cs`](../main/RandomVariability.cs) contains code that manipulates a particle system in Unity.
