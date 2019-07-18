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
                    using (var context = new TelemetryContext())
                    {
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
                            context.BulkInsert(new List<Gps>(GpsCollection));
                            GpsCollection.Clear();
                        }
                        if (ErrorCollection.Count > 0)
                        {
                            await context.BulkInsertAsync(new List<Error>(ErrorCollection));
                            ErrorCollection.Clear();
                        }
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