using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using Telemetry;
using Telemetry.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole.SerialReader
{
    public partial class SerialReader
    {
        private static readonly ObservableCollection<Motor> MotorList = new ObservableCollection<Motor>();
        private static readonly ObservableCollection<MPPT> MpptList = new ObservableCollection<MPPT>();
        private static readonly ObservableCollection<Bms> BmsList = new ObservableCollection<Bms>();
        private static readonly ObservableCollection<Gps> GpsList = new ObservableCollection<Gps>();

        private static void BulkListInserter()
        {
            while (true)
                try
                {
                    using var context = new TelemetryContext();
                    if (BmsList.Count > 0)
                    {
                        context.BatteryManagementSystems.AddRange(new List<Bms>(BmsList));
                        BmsList.Clear();
                    }

                    if (MotorList.Count > 0)
                    {
                        context.Motors.AddRange(new List<Motor>(MotorList));
                        MotorList.Clear();
                    }

                    if (MpptList.Count > 0)
                    {
                        context.MPPTs.AddRange(new List<MPPT>(MpptList));
                        MpptList.Clear();
                    }

                    if (GpsList.Count > 0)
                    {
                        context.GPSs.AddRange(new List<Gps>(GpsList));
                        GpsList.Clear();
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