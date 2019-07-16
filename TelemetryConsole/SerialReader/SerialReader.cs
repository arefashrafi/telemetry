// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerialReader.cs" company="JU Solar Team">
//   Aref Ashrafi
// </copyright>
// <summary>
//   Class for reading from the serial port and inserting to the database using EF Core
//   Class is also determining what model is used from the serial port byteArray
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using NmeaParser;
using NmeaParser.Nmea;
using Telemetry;
using Telemetry.Misc;
using TelemetryDependencies.Models;
using TelemetryDependencies.Structs;

namespace TelemetryConsole.SerialReader
{
    /// <summary>
    ///     Class for reading from the serial port and inserting to the database using EF Core
    ///     Class is also determining what model is used from the serial port byteArray
    /// </summary>
    public partial class SerialReader : Constants

    {
        private readonly ConcurrentQueue<byte> _rxByteQueue = new ConcurrentQueue<byte>();
        private TcpListener _server;

        public async Task InitSerialGps()
        {
            string portName = System.Configuration.ConfigurationManager.AppSettings["COMPORT"];
            try
            {
                var port = new SerialPort(portName, 9600); //change parameters to match your serial port
                var device = new SerialPortDevice(port);
                device.MessageReceived += DeviceOnMessageReceived;
                await device.OpenAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }

        private void DeviceOnMessageReceived(object o, NmeaMessageReceivedEventArgs args)
        {
            try
            {
                if (!(args.Message is Gga gngga)) return;
                using var context = new TelemetryContext();
                context.GPSs.Add(new Gps
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
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        private void WifiListener()
        {
            try
            {
                // Set the TcpListener on port 13000.
                const int port = 20526;
                var localAddr = IPAddress.Parse("192.168.137.1");

                // TcpListener server = new TcpListener(port);
                _server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                _server.Start();

                // Buffer for reading data
                byte[] bytes = new byte[128];
                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    var client = _server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    // Get a stream object for reading and writing
                    var stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        lock (_rxByteQueue)
                        {
                            foreach (byte p in bytes) _rxByteQueue.Enqueue(p);
                        }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                _server.Stop();
            }


            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        public void StartAllDependenciesThread()
        {
            var repThread = new Thread(BulkListInserter);
            var wifiThread = new Thread(WifiListener);
            var queureader = new Thread(ThreadQueueReader);
            queureader.Start();
            wifiThread.Start();
            repThread.Start();
        }

        /// <summary>
        ///     This method will start a thread that starts reading the receiveQueue to insert data into the local database
        /// </summary>
        private void ThreadQueueReader()
        {
            // Create thread for handling data from receiveQueue
            // Input will be faster than processing, thread is needed to process data so data loss is not happening

            // Loop if receiveQueue contains data while serial port is open
            do
            {
                byte[] packetArray;
                lock (_rxByteQueue)
                {
                    if (_rxByteQueue.Count < bufSize) continue;
                    packetArray = _rxByteQueue.Take(bufSize).ToArray();
                }

                byte startByte = packetArray[StartByteIndex];
                byte id = packetArray[IdIndex];
                byte dataLength = packetArray[DataLengthIndex];

                if (startByte == ExpectedStartByte && dataLength <= packetArray.Length)
                {
                    byte[] dataSubsetPacket = packetArray.RangeSubset(3, dataLength);
                    byte[] crcSubsetPacket = packetArray.RangeSubset(dataLength + 3, 4);
                    if (crcSubsetPacket == BitConverter.GetBytes(new Crc32().Get(dataSubsetPacket))) continue;

                    if (id == BmsId)
                    {
                        if (dataLength <= 40)
                        {
                            var bMsStruct = Extensions.ByteArrayToStructure<BmsStruct>(dataSubsetPacket);
                            SendToDBHandler(bMsStruct);
                        }
                    }


                    else if (id == MotorId)
                    {
                        if (dataLength == 28)
                        {
                            var motorStruct = Extensions.ByteArrayToStructure<MotorStruct>(dataSubsetPacket);
                            SendToDBHandler(motorStruct);
                        }
                    }


                    else if (id == MotorIdOld)
                    {
                        if (dataLength <= 32)
                        {
                            var motorStructOld =
                                Extensions.ByteArrayToStructure<MotorStructOld>(dataSubsetPacket);
                            SendToDBHandler(motorStructOld);
                        }
                    }

                    else if (id == GpsId)
                    {
                        if (dataLength <= 32)
                        {
                            var gpsStruct = Extensions.ByteArrayToStructure<GpsStruct>(dataSubsetPacket);
                            SendToDBHandler(gpsStruct);
                        }
                    }

                    int length = dataLength + 3 + 4; // +3+3 is for crc and start byte etc
                    int totalLength = length;
                    for (int i = 0; i < totalLength; i++)
                    {
                        byte value;
                        lock (_rxByteQueue)
                        {
                            _rxByteQueue.TryDequeue(out value);
                        }
                    }
                }
                else
                {
                    lock (_rxByteQueue)
                    {
                        byte value;
                        _rxByteQueue.TryDequeue(out value); // do this until we find startByte
                    }
                }
            } while (true);
        }
    }
}