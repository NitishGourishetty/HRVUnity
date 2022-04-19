# UnityBioFeedbackTesting
Getting data from Arduino into Unity Serial Ports

Items necessary:

- Arduino Uno (any model is fine)
- USB B cable
- HC-05 Bluetooth Module
- Pulse Sensor

Step 1: Connect Arduino to Computer containing Arduino IDE and HRVSensor.ino using a USB B cable

Step 2: Connect the Pulse Sensor to the Arduino (black wire to Ground, red wire to 3.3V power, and purple wire to A0 - Analog Input 0)

Step 3: Verify and Upload the HRVSensor.ino sketch to the Arduino Uno (make sure to select the correct COM port under Tools

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
