using System;

namespace TelemetryGUI.Util
{
    public class EventSource
    {
        public static event EventHandler<EntityEventArgs> Event = delegate { };

        public static void RaiseEvent(object data)
        {
            Event.Invoke(null, new EntityEventArgs(data));
        }
    }

    public class EntityEventArgs : EventArgs
    {
        public EntityEventArgs(object data)
        {
            Data = data;
        }

        public object Data { get; set; }
    }
}