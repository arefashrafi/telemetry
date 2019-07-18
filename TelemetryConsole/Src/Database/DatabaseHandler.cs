using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                    MotorCollection.Add(new Motor
                    {
                        BatteryVoltage = 32,
                        BatteryCurrent = 32,
                        CurrentDirection = 32,
                        MotorCurrent = 32,
                        TempControl = 32,
                        TempMotor = 32,
                        MotorRPM = 32,
                        OutputDuty = 32,
                        OutputDutyType = 32,
                        MotorDriveMode = 32,
                        FailModeInfo1 = 32,
                        FailModeInfo2 = 32,
                        PresentCorePos = 32,
                        FailModeInfo = 32,
                        Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                    using var context = new TelemetryContext();
                    if (BmsCollection.Count > 0)
                    {
                        await context.BulkInsertAsync(new List<Bms>(BmsCollection));
                        BmsCollection.Clear();
                    }
                    if (MotorCollection.Count > 0)
                    {
                        await context.BulkInsertAsync(new List<Motor>(MotorCollection));
                        MotorCollection.Clear();
                    }
                    if (MpptCollection.Count > 0)
                    {
                        await context.BulkInsertAsync(new List<MPPT>(MpptCollection));
                        MpptCollection.Clear();
                    }
                    if (GpsCollection.Count > 0)
                    {
                        await context.BulkInsertAsync(new List<Gps>(GpsCollection));
                        GpsCollection.Clear();
                    }
                    if (ErrorCollection.Count > 0)
                    {
                        await context.BulkInsertAsync(new List<Error>(ErrorCollection));
                        ErrorCollection.Clear();
                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e+"ArgumentNullException");
                    MotorCollection.Clear();
                    BmsCollection.Clear();
                    GpsCollection.Clear();
                }
            }
        }
    }
}