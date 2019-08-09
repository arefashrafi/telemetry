using System;
using TelemetryDependencies.Models;

namespace TelemetryGUI.Util
{
    public class EventSource
    {
        public static event EventHandler<EntityEventArgs> EventMotor = delegate { };
        public static event EventHandler<EntityEventArgs> EventBms = delegate { };
        public static event EventHandler<EntityEventArgs> EventError = delegate { };
        public static event EventHandler<EntityEventArgs> EventGps = delegate { };
        public static event EventHandler<EntityEventArgs> EventMppt = delegate { };
        public static event EventHandler<EntityEventArgs> EventMessage = delegate { };
        public static void RaiseEvent(object data, string time)
        {
            if (data.GetType() == typeof(Motor)) EventMotor.Invoke(null, new EntityEventArgs(data, time));
            if (data.GetType() == typeof(Message)) EventMessage.Invoke(null, new EntityEventArgs(data, time));
            if (data.GetType() == typeof(Bms)) EventBms.Invoke(null, new EntityEventArgs(data, time));
            if (data.GetType() == typeof(Error)) EventError.Invoke(null, new EntityEventArgs(data, time));
            if (data.GetType() == typeof(Gps)) EventGps.Invoke(null, new EntityEventArgs(data, time));
            if (data.GetType() == typeof(MPPT)) EventGps.Invoke(null, new EntityEventArgs(data, time));
        }
    }

    public class EntityEventArgs : EventArgs
    {
        public EntityEventArgs(object data, string time)
        {
            Data = data;
            Time = time;
        }

        public object Data { get; set; }
        public string Time { get; set; }
    }
}