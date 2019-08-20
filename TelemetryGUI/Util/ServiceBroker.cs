using System;
using System.Configuration;
using System.Windows;
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
                var motordep = new SqlTableDependency<Motor>(ConnectionString, "Motors");
                motordep.OnChanged += ChangedMotor;
                motordep.Start();
                var gpsdep = new SqlTableDependency<Gps>(ConnectionString, "GPSs");
                gpsdep.OnChanged += ChangedGps;
                gpsdep.Start();
                var bmsdep = new SqlTableDependency<Bms>(ConnectionString, "BatteryManagementSystems");
                bmsdep.OnChanged += ChangedBms;
                bmsdep.Start();
                var mpptdep = new SqlTableDependency<MPPT>(ConnectionString, "MPPTs");
                mpptdep.OnChanged += ChangedMppt;
                mpptdep.Start();
                var errordep = new SqlTableDependency<Error>(ConnectionString, "Errors");
                errordep.OnChanged += ChangedError;
                errordep.Start();
                var messagedep = new SqlTableDependency<Message>(ConnectionString, "Messages");
                messagedep.OnChanged += ChangedMessage;
                messagedep.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangedMotor(object sender, RecordChangedEventArgs<Motor> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            Motor changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }

        private void ChangedMessage(object sender, RecordChangedEventArgs<Message> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            Message changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, null);
        }

        private void ChangedGps(object sender, RecordChangedEventArgs<Gps> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            Gps changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.TimeStamp);
        }

        private void ChangedBms(object sender, RecordChangedEventArgs<Bms> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            Bms changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }

        private void ChangedMppt(object sender, RecordChangedEventArgs<MPPT> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            MPPT changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }

        private void ChangedError(object sender, RecordChangedEventArgs<Error> e)
        {
            if (e.ChangeType != ChangeType.Insert) return;
            Error changedEntity = e.Entity;
            EventSource.RaiseEvent(changedEntity, changedEntity.Time);
        }
    }
}