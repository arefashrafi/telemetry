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
/*                    BmsCollection.Add(new Bms
                    {
                        MinVolt = 32,
                        MinVoltId = 23,
                        MaxVolt = 13,
                        MaxVoltId = 31,
                        Volt = 33,
                        Current = 22,
                        Status = 15,
                        Soc = 57,
                        MinTemp = 7,
                        MinTempId = 6,
                        MaxTemp = 76,
                        MaxTempId = 56,
                        FWVersion = 24,
                        CycleTime = 45,
                        MCUTemp = 5,
                        RoundtripTm = 13,
                        Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });*/
                    MotorCollection.Add(new Motor
                    {
                        BatteryVoltage = 32,
                        BatteryCurrent = 31,
                        CurrentDirection = 2,
                        MotorCurrent = 5,
                        TempControl = 35,
                        TempMotor = 1111,
                        MotorRPM = 333,
                        OutputDuty = 23,
                        OutputDutyType = 32,
                        MotorDriveMode = 31,
                        FailModeInfo1 = 66,
                        FailModeInfo2 = 65,
                        PresentCorePos = 54,
                        FailModeInfo = 312,
                        Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
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