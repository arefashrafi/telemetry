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
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e+"ArgumentNullException");
                }
            }
        }
    }
}