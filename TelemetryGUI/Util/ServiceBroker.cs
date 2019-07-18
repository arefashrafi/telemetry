using System;
using System.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using TelemetryDependencies.Models;

namespace TelemetryGUI.Util
{
    public class ServiceBroker
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Broker()
        {
            try
            {
                SqlTableDependency<Motor> motordep = new SqlTableDependency<Motor>(ConnectionString, "Motors");
                motordep.OnChanged += ChangedMotor;
                motordep.Start();
                SqlTableDependency<Gps> gpsdep = new SqlTableDependency<Gps>(ConnectionString, "GPSs");
                gpsdep.OnChanged += ChangedGps;
                gpsdep.Start();
                SqlTableDependency<Bms> bmsdep =
                    new SqlTableDependency<Bms>(ConnectionString, "BatteryManagementSystems");
                bmsdep.OnChanged += ChangedBms;
                bmsdep.Start();
                SqlTableDependency<MPPT> mpptdep = new SqlTableDependency<MPPT>(ConnectionString, "MPPTs");
                mpptdep.OnChanged += ChangedMppt;
                mpptdep.Start();
                SqlTableDependency<Error> errordep = new SqlTableDependency<Error>(ConnectionString, "Errors");
                errordep.OnChanged += ChangedError;
                errordep.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void ChangedMotor(object sender, RecordChangedEventArgs<Motor> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            var changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }

        private void ChangedGps(object sender, RecordChangedEventArgs<Gps> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            var changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.TimeStamp);
        }

        private void ChangedBms(object sender, RecordChangedEventArgs<Bms> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            var changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }

        private void ChangedMppt(object sender, RecordChangedEventArgs<MPPT> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            var changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }

        private void ChangedError(object sender, RecordChangedEventArgs<Error> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            var changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }
    }
}