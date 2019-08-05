using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole.Database
{
    public partial class TelemetryControl
    {
        public static async void DatabaseHandler()
        {
            while (true)
            {
                try
                {
                    GpsCollection.Add(new Gps
                    {
                        DeviceId = 1,
                        LAT = 53.3123,
                        LONG = 14.1551,
                        ALT = 111,
                        SPEED = 321,
                        HEADING = 3,
                        GPSFIX = 3,
                        DIST = 321,
                        TDIST = 32,
                        ACCX = 321,
                        ACCY = 13,
                        ACCZ = 3,
                        GYRX = 3,
                        GYRY = 3,
                        GYRZ = 3,
                        TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                    GpsCollection.Add(new Gps
                    {
                        DeviceId = 0,
                        LAT = 53.3123,
                        LONG = 14.1551,
                        ALT = 111,
                        SPEED = 321,
                        HEADING = 3,
                        GPSFIX = 3,
                        DIST = 321,
                        TDIST = 32,
                        ACCX = 321,
                        ACCY = 13,
                        ACCZ = 3,
                        GYRX = 3,
                        GYRY = 3,
                        GYRZ = 3,
                        TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                    Thread.Sleep(500);
                    using (TelemetryContext context = new TelemetryContext())
                    {
                        try
                        {
                            if (BmsCollection.Count > 0)
                            { 
                                context.BulkInsert(new List<Bms>(BmsCollection));
                                BmsCollection.Clear();
                            }
                            if (MotorCollection.Count > 0)
                            { 
                                context.BulkInsert(new List<Motor>(MotorCollection));
                                MotorCollection.Clear();
                            }
                            if (MpptCollection.Count > 0)
                            {
                                await context.BulkInsertAsync(new List<MPPT>(MpptCollection));
                                MpptCollection.Clear();
                            }
                            if (GpsCollection.Count > 0)
                            { 
                                context.BulkInsert(new List<Gps>(GpsCollection));
                                GpsCollection.Clear();
                            }
                            if (ErrorCollection.Count > 0)
                            {
                                await context.BulkInsertAsync(new List<Error>(ErrorCollection));
                                ErrorCollection.Clear();
                            }
                            if (DebugCollection.Count > 0)
                            {
                                await context.BulkInsertAsync(new List<Debug>(DebugCollection));
                                DebugCollection.Clear();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        
                    }
                        
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e+"ArgumentNullException");
                }
            }
        }
    }
}