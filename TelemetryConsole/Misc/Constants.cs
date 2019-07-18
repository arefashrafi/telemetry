using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using TelemetryDependencies.Models;

namespace TelemetryConsole.Misc
{
    public class Constants
    {
        protected const int ExpectedStartByte = 0x26;
        protected const int IdIndex = 1;
        protected const int StartByteIndex = 0;
        protected const int DataLengthIndex = 2;
        protected const int MotorId = 0x72;
        protected const int MotorIdOld = 0x71;
        protected const int BmsId = 0x70;
        protected const int GpsId = 0x73;
        protected const int BuffSize = 128;
        protected const int DebugId = 0x74;
        public static readonly ConcurrentQueue<byte> RxByteQueue = new ConcurrentQueue<byte>();
        
        
        public static readonly ObservableCollection<Motor> MotorCollection = new ObservableCollection<Motor>();
        public static readonly ObservableCollection<MPPT> MpptCollection = new ObservableCollection<MPPT>();
        public static readonly ObservableCollection<Bms> BmsCollection = new ObservableCollection<Bms>();
        public static readonly ObservableCollection<Gps> GpsCollection = new ObservableCollection<Gps>();
        public static readonly ObservableCollection<Error> ErrorCollection = new ObservableCollection<Error>();
        public static readonly ObservableCollection<Debug> DebugCollection = new ObservableCollection<Debug>();
    }
}