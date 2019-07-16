using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole.Src.Database
{
    public partial class TelemetryControl
    {
        private static readonly ObservableCollection<Motor> MotorCollection = new ObservableCollection<Motor>();
        private static readonly ObservableCollection<MPPT> MpptCollection = new ObservableCollection<MPPT>();
        private static readonly ObservableCollection<Bms> BmsCollection = new ObservableCollection<Bms>();
        private static readonly ObservableCollection<Gps> GpsCollection = new ObservableCollection<Gps>();
        private static readonly ObservableCollection<Error> ErrorCollection = new ObservableCollection<Error>();

        public static void DatabaseHandler()
        {
            while (true)
            {
                BmsCollection.Add(new Bms
                {
                    MinVolt = 15,
                    MinVoltId = 122,
                    MaxVolt = 3,
                    MaxVoltId = 11,
                    Volt = 44,
                    Current = 16,
                    Status = 74,
                    Soc = 15,
                    MinTemp = 646,
                    MinTempId = 14,
                    MaxTemp = 24,
                    MaxTempId = 5,
                    FWVersion = 44,
                    CycleTime = 12,
                    MCUTemp = 12,
                    RoundtripTm = 123,
                    Time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                });
                ErrorCollection.Add(new Error
                {
                    ExceptionSource = "Test",
                    Message = "Test",
                    Time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                });
                try
                {
                    using var context = new TelemetryContext();
                    if (BmsCollection.Count > 0)
                    {
                        context.BatteryManagementSystems.AddRange(new List<Bms>(BmsCollection));
                        BmsCollection.Clear();
                    }

                    if (MotorCollection.Count > 0)
                    {
                        context.Motors.AddRange(new List<Motor>(MotorCollection));
                        MotorCollection.Clear();
                    }

                    if (MpptCollection.Count > 0)
                    {
                        context.MPPTs.AddRange(new List<MPPT>(MpptCollection));
                        MpptCollection.Clear();
                    }

                    if (GpsCollection.Count > 0)
                    {
                        context.GPSs.AddRange(new List<Gps>(GpsCollection));
                        GpsCollection.Clear();
                    }
                    if (ErrorCollection.Count > 0)
                    {
                        context.Errors.AddRange(new List<Error>(ErrorCollection));
                        ErrorCollection.Clear();
                    }

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                catch (Exception ex)
                {
                    using var context = new TelemetryContext();
                    context.Errors.Add(new Error
                    {
                        ExceptionSource = ex.Source,
                        Message = ex.Message,
                        Time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                    Extensions.PrintProperties(ex);
                }
            }
        }
    }
}