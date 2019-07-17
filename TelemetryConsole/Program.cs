using System;
using System.Threading;
using TelemetryConsole.SerialReader;
using TelemetryConsole.Src.Wifi;
using TelemetryControl = TelemetryConsole.Database.TelemetryControl;

namespace TelemetryConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread databaseHandlerThread = new Thread(TelemetryControl.DatabaseHandler);
            Thread databaseSerializerThread = new Thread(TelemetryControl.DataSerializer);
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