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
using System.Linq;
using TelemetryConsole.Misc;
using TelemetryDependencies.Structs;

namespace TelemetryConsole.Database
{
    /// <summary>
    ///     Class for reading from the serial port and inserting to the database using EF Core
    ///     Class is also determining what model is used from the serial port byteArray
    /// </summary>
    public partial class TelemetryControl : Constants

    {
        /// <summary>
        ///     This method will start a thread that starts reading the receiveQueue to insert data into the local database
        /// </summary>
        public static void DataSerializer()
        {
            // Create thread for handling data from receiveQueue
            // Input will be faster than processing, thread is needed to process data so data loss is not happening

            // Loop if receiveQueue contains data while serial port is open
            do
            {
                byte[] packetArray = new byte[128];
                lock (RxByteQueue)
                {
                    try
                    {
                        if (RxByteQueue.Count > BuffSize)
                            packetArray = RxByteQueue.Take(BuffSize).ToArray();
                        else
                            continue;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                //Identify packet
                byte startByte = packetArray[StartByteIndex];
                byte id = packetArray[IdIndex];
                byte dataLength = packetArray[DataLengthIndex];

                if (startByte == ExpectedStartByte && dataLength <= packetArray.Length)
                    try
                    {
                        byte[] dataSubsetPacket = packetArray.RangeSubset(3, dataLength);
                        
                        byte[] crcSubsetPacket = packetArray.RangeSubset(dataLength + 3, 4);
                        if (crcSubsetPacket == BitConverter.GetBytes(new Crc32().Get(dataSubsetPacket))) continue;

                        if (id == BmsId)
                        {
                            if (dataLength == 38)
                            {
                                var bMsStruct = Extensions.ByteArrayToStructure<BmsStruct>(dataSubsetPacket);
                                DatabaseParser(bMsStruct);
                            }
                        }

                        else if (id == DebugId)
                        {
                            if (dataLength == 1)
                            {
                                var debugStruct = Extensions.ByteArrayToStructure<DebugStruct>(dataSubsetPacket);
                                DatabaseParser(debugStruct);
                            }
                        }
                        else if (id == GpsId)
                        {
                            if (dataLength == 61)
                            {
                                var gpsStruct = Extensions.ByteArrayToStructure<GpsStruct>(dataSubsetPacket);
                                DatabaseParser(gpsStruct);
                            }
                        }


                        else if (id == MotorId)
                        {
                            if (dataLength == 29)
                            {
                                var motorStruct = Extensions.ByteArrayToStructure<MotorStruct>(dataSubsetPacket);
                                DatabaseParser(motorStruct);
                            }
                        }

                        else if (id == GpsId)
                        {
                            if (dataLength <= 32)
                            {
                                var gpsStruct = Extensions.ByteArrayToStructure<GpsStruct>(dataSubsetPacket);
                                DatabaseParser(gpsStruct);
                            }
                        }
                        else if (id == AckId)
                        {
                            if (dataLength == 1)
                            {
                                var ackStruct = Extensions.ByteArrayToStructure<AckStruct>(dataSubsetPacket);
                                DatabaseParser(ackStruct);
                            }
                        }

                        int length = dataLength + 3 + 4; // +3+3 is for crc and start byte etc
                        int totalLength = length;
                        for (int i = 0; i < totalLength; i++)
                            lock (RxByteQueue)
                            {
                                RxByteQueue.TryDequeue(out _);
                            }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e+"Dataserializer");
                    }
                else
                    lock (RxByteQueue)
                    {
                        RxByteQueue.TryDequeue(out byte _); // do this until we find startByte
                    }
            } while (true);
        }
    }
}