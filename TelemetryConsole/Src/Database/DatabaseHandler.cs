using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole.Database
{
    public partial class TelemetryControl
    {
        private static readonly ObservableCollection<Motor> MotorCollection = new ObservableCollection<Motor>();
        private static readonly ObservableCollection<MPPT> MpptCollection = new ObservableCollection<MPPT>();
        private static readonly ObservableCollection<Bms> BmsCollection = new ObservableCollection<Bms>();
        private static readonly ObservableCollection<Gps> GpsCollection = new ObservableCollection<Gps>();
        private static readonly ObservableCollection<Error> ErrorCollection = new ObservableCollection<Error>();

        public static async void DatabaseHandler()
        {
            while (true)
            {
                try
                {
                    using TelemetryContext context = new TelemetryContext();
                    if (BmsCollection.Count > 0)
                    {
                        await context.BatteryManagementSystems.AddRangeAsync(new List<Bms>(BmsCollection));
                        BmsCollection.Clear();
                    }

                    if (MotorCollection.Count > 0)
                    {
                        await context.Motors.AddRangeAsync(new List<Motor>(MotorCollection));
                        MotorCollection.Clear();
                    }

                    if (MpptCollection.Count > 0)
                    {
                        await context.MPPTs.AddRangeAsync(new List<MPPT>(MpptCollection));
                        MpptCollection.Clear();
                    }

                    if (GpsCollection.Count > 0)
                    {
                        await context.GPSs.AddRangeAsync(new List<Gps>(GpsCollection));
                        GpsCollection.Clear();
                    }
                    if (ErrorCollection.Count > 0)
                    {
                        await context.Errors.AddRangeAsync(new List<Error>(ErrorCollection));
                        ErrorCollection.Clear();
                    }

                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                catch (Exception ex)
                {
                    using var context = new TelemetryContext();
                    await context.Errors.AddAsync(new Error
                    {
                        ExceptionSource = ex.Source,
                        Message = ex.Message,
                        Time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                    Extensions.PrintProperties(ex.Message);
                }
            }
        }
    }
}