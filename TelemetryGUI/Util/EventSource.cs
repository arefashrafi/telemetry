using System;

namespace TelemetryGUI.Util
{
    public class EventSource
    {
        public static event EventHandler<EntityEventArgs> Event = delegate { };

        public static void RaiseEvent(object data,string time)
        {
            Event.Invoke(null, new EntityEventArgs(data,time));
        }
    }

    public class EntityEventArgs : EventArgs
    {
        public EntityEventArgs(object data,string time)
        {
            Data = data;
            Time = time;

        }

        public object Data { get; set; }
        public string Time { get; set; }
    }
}