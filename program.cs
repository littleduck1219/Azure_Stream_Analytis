using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
using Microsoft.Azure.Devices.Client;
using Newtonsoft;

namespace IoTClient
{
    internal class Program
    {
        private static System.Timers.Timer SensorTimer;
        private const string DeviceConnectionString = "HostName=labuser15iot.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=QjL4P0hyT2XGDSryDRM03HpjlWRO9CayodOrqCbG/sI=";
        private const string DeviceID = "Device1";
        private static DeviceClient SensorDevice = null;

        private static DummySensor DummySensor = new DummySensor();
        static void Main(string[] args)
        {
            SetTimer();

            SensorDevice = DeviceClient.CreateFromConnectionString(DeviceConnectionString,DeviceID);

            if(SensorDevice == null)
            {
                Console.WriteLine("Failed to create DeviceClient!");
                SensorTimer.Stop();
            }

            Console.WriteLine("\nPress Enter Key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            SensorTimer.Stop();
            SensorTimer.Dispose();
        }

        private static void SetTimer()
        {
            SensorTimer = new System.Timers.Timer(2000);
            SensorTimer.Elapsed += SensorTimer_Elapsed;
            SensorTimer.AutoReset = true;
            SensorTimer.Enabled = true;
        }

        private static async void SensorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
            await SendEvent();
            await ReceiveCommands();
        }

        private static async Task SendEvent()
        {
            WeatherModel model = DummySensor.GetWeatherModel(DeviceID);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            Console.WriteLine(json);

            Message message = new Message(Encoding.UTF8.GetBytes(json));
            await SensorDevice.SendEventAsync(message);
        }

        static async Task ReceiveCommands()
        {
            Message receivedMessage;
            string messageData;

            receivedMessage = await SensorDevice.ReceiveAsync(TimeSpan.FromSeconds(1));

            if (receivedMessage != null)
            {
                messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                Console.WriteLine("\t{0}> Received message: {1}", DateTime.Now.ToLocalTime(), messageData);

                await SensorDevice.CompleteAsync(receivedMessage);
            }
        }
    }
}
