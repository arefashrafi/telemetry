using System;
using System.Threading;
using TelemetryConsole.Database;
using TelemetryConsole.GPS;
using TelemetryConsole.Misc;
using TelemetryConsole.Wifi;

namespace TelemetryConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Init all the keys from App.config
            Constants.Init();

            Thread databaseHandlerThread = new Thread(TelemetryControl.DatabaseHandler);
            Thread databaseSerializerThread = new Thread(TelemetryControl.DataSerializer);
            Console.WriteLine(DateTime.Now);
            databaseHandlerThread.Start();
            databaseSerializerThread.Start();
            DataReader.StartListener();
            GpsSerialReceiver.StartListener();
            AsynchronousSocketListener.StartListener();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application is running and Waiting for data");
            do
            {
                Console.ReadKey();
            } while (Console.ReadKey().Key != ConsoleKey.F5);
        }
    }
}