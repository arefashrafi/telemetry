using System;
using System.Configuration;
using System.Globalization;
using System.IO.Ports;
using NmeaParser;
using NmeaParser.Nmea;
using Telemetry.App;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole.GPS
{
    public class GpsSerialReceiver : Constants
    {
        public static void StartListener()
        {
            string portName = ConfigurationManager.AppSettings["GPSCOMPORT"];
            try
            {
                SerialPort port = new SerialPort(portName, 9600); //change parameters to match your serial port
                SerialPortDevice device = new SerialPortDevice(port);
                device.MessageReceived += DeviceOnMessageReceived;
                device.OpenAsync().Wait();
                Console.WriteLine("GPS Opened");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DeviceOnMessageReceived(object o, NmeaMessageReceivedEventArgs args)
        {
            try
            {
                if (!(args.Message is Gga gngga)) return;
                using (TelemetryContext context = new TelemetryContext())
                {
                    context.GPSs.AddAsync(new Gps
                    {
                        DeviceId = 1,
                        Lat = gngga.Latitude,
                        Long = gngga.Longitude,
                        Alt = gngga.Altitude,
                        Dist = 0,
                        Tdist = 0,
                        Gyrx = 0,
                        Gyry = 0,
                        Gyrz = 0,
                        Gpsfix = 0,
                        Accx = 0,
                        Accy = 0,
                        Accz = 0,
                        Heading = 0,
                        Speed = 0,
                        TimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                    context.SaveChangesAsync().Wait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}