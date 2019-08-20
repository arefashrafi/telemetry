using System;
using System.Configuration;
using System.Globalization;
using System.IO.Ports;
using NmeaParser;
using NmeaParser.Nmea;
using Telemetry.App;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole.SerialReader
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
                device.OpenAsync();
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
                        LAT = gngga.Latitude,
                        LONG = gngga.Longitude,
                        ALT = gngga.Altitude,
                        DIST = 0,
                        TDIST = 0,
                        GYRX = 0,
                        GYRY = 0,
                        GYRZ = 0,
                        GPSFIX = 0,
                        ACCX = 0,
                        ACCY = 0,
                        ACCZ = 0,
                        HEADING = 0,
                        SPEED = 0,
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