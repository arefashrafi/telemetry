using System;
using System.Configuration;
using System.Globalization;
using System.IO.Ports;
using NmeaParser;
using NmeaParser.Nmea;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole.SerialReader
{
    public class GpsSerialReceiver : Constants
    {
        public static void StartListening()
        {
            string portName = ConfigurationManager.AppSettings["COMPORT"];
            try
            {
                var port = new SerialPort(portName, 9600); //change parameters to match your serial port
                var device = new SerialPortDevice(port);
                device.MessageReceived += DeviceOnMessageReceived;
                device.OpenAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void DeviceOnMessageReceived(object o, NmeaMessageReceivedEventArgs args)
        {
            try
            {
                if (!(args.Message is Gga gngga)) return;
                using (var context = new TelemetryContext())
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
                        GYRZ = 2,
                        GPSFIX = 0,
                        ACCX = 0,
                        ACCY = 0,
                        ACCZ = 0,
                        HEADING = 0,
                        SPEED = 0,
                        TimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("GPS Parsing most likely database");
            }
        }
    }
}