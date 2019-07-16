using System;
using System.Threading;
using TelemetryConsole.SerialReader;
using TelemetryConsole.Src.Database;
using TelemetryConsole.Src.Wifi;

namespace TelemetryConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread databaseHandlerThread = new Thread(TelemetryControl.DatabaseHandler);
            Thread databaseSerializerThread = new Thread(TelemetryControl.DataSerializer);
            Console.WriteLine(DateTime.Now);
            
            
            AsynchronousSocketListener.StartListening();
            GpsSerialReceiver.StartListening();
            
            
            databaseHandlerThread.Start();
            databaseSerializerThread.Start();
            
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application is running and Waiting for data");
            do
            {
                Console.ReadKey();
            } while (Console.ReadKey().Key != ConsoleKey.F5);
        }
    }
}