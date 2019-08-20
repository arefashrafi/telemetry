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
                        Random r = new Random();
                        
                        MotorCollection.Add(new Motor
                        {
                            BatteryVoltage = r.Next(100),
                            BatteryCurrent = r.Next(100),
                            BatteryCurrentDir = r.Next(100),
                            MotorCurrent = r.Next(100),
                            MotorCurrentDir = r.Next(100),
                            TempControl = r.Next(100),
                            TempMotor = r.Next(100),
                            MotorRpm = r.Next(100),
                            OutputDuty = r.Next(100),
                            OutputDutyType = r.Next(100),
                            MotorDriveMode = r.Next(100),
                            FailModeInfo = r.Next(100),
                            TempErrLevel = r.Next(100),
                            PresentCorePos = r.Next(100),
                            Gear = r.Next(100),
                            FailModeInfo2 = r.Next(100),
                            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                        });
                        BmsCollection.Add(new Bms
                        {

                            MinVolt = r.Next(100) ,
                            MinVoltId = r.Next(100) ,
                            MaxVolt = r.Next(100) ,
                            MaxVoltId = r.Next(100) ,
                            Volt = r.Next(100) ,
                            Current = r.Next(100) ,
                            Status = r.Next(100) ,
                            Soc = r.Next(100) ,
                            MinTemp = r.Next(100) ,
                            MinTempId = r.Next(100) ,
                            MaxTemp = r.Next(100) ,
                            MaxTempId = r.Next(100) ,
                            FWVersion = r.Next(100) ,
                            CycleTime = r.Next(100) ,
                            MCUTemp = r.Next(100) ,
                            RoundtripTm = r.Next(100) ,
                            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                        });
                        Thread.Sleep(100);
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