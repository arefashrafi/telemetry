using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using TelemetryConsole.Database;
using TelemetryConsole.SerialReader;
using TelemetryConsole.Src.Wifi;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;

namespace TelemetryConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDatabase();
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
        protected static void CreateDatabase()
        {
            //try
            //{
            //    string connectionString = ConfigurationManager.AppSettings["DefaultConnection"];
            //    string location = ConfigurationManager.AppSettings["ScriptLocation"];

            //    string script = File.ReadAllText(location);

            //    SqlConnection conn = new SqlConnection(connectionString);

            //    Server server = new Server(new ServerConnection(conn));

            //    server.ConnectionContext.ExecuteNonQuery(script);
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("Could not create database");
            //}

        }
    }
}