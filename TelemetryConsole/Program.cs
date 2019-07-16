using System;

namespace Telemetry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            var serialReader = new TelemetryConsole.SerialReader.SerialReader();
            serialReader.StartAllDependenciesThread();
            serialReader.InitSerialGps();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application is running and Waiting for data");
            do
            {
                Console.ReadKey();
            } while (Console.ReadKey().Key != ConsoleKey.F5);
        }
    }
}