using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using TelemetryConsole.Database;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;
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