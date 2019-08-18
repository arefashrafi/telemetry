using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using Telemetry.App;
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
                    using (TelemetryContext context = new TelemetryContext())
                    {
/*                        MotorCollection.Add(new Motor
                        {
                            BatteryVoltage = 32,
                            BatteryCurrent = 321,
                            BatteryCurrentDir = 312,
                            MotorCurrent = 33,
                            MotorCurrentDir = 15,
                            TempControl = 23,
                            TempMotor = 23,
                            MotorRpm = 213,
                            OutputDuty = 321,
                            OutputDutyType = 233,
                            MotorDriveMode = 123,
                            FailModeInfo = 3211,
                            TempErrLevel = 123,
                            PresentCorePos = 213,
                            Gear = 3,
                            FailModeInfo2 = 23,
                            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                        });
                        BmsCollection.Add(new Bms
                        {
                            MinVolt = 100,
                            MinVoltId = 100,
                            MaxVolt = 100,
                            MaxVoltId = 100,
                            Volt = 100,
                            Current = 100,
                            Status =100 ,
                            Soc = 100,
                            MinTemp = 100,
                            MinTempId = 100,
                            MaxTemp = 100,
                            MaxTempId = 100,
                            FWVersion = 100,
                            CycleTime = 100,
                            MCUTemp = 100,
                            RoundtripTm = 100,
                            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                        });
                        Thread.Sleep(300);*/
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
                            if (MessageCollection.Count > 0)
                            {
                                await context.BulkInsertAsync(new List<Message>(MessageCollection));
                                MessageCollection.Clear();
                            }

                            await context.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        
                    }
                        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}