using System;
using System.Threading;
using TelemetryConsole.Database;
using TelemetryConsole.SerialReader;
using TelemetryConsole.Src.Wifi;

namespace TelemetryConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var databaseHandlerThread = new Thread(TelemetryControl.DatabaseHandler);
            var databaseSerializerThread = new Thread(TelemetryControl.DataSerializer);
            Console.WriteLine(DateTime.Now);
            databaseHandlerThread.Start();
            databaseSerializerThread.Start();
            GpsSerialReceiver.StartListening();
            AsynchronousSocketListener.StartListening();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application is running and Waiting for data");
            do
            {
                Console.ReadKey();
            } while (Console.ReadKey().Key != ConsoleKey.F5);
        }
    }
}