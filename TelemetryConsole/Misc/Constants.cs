using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Configuration;
using TelemetryDependencies.Models;

namespace TelemetryConsole.Misc
{
    public static class Constants
    {
        public static int ExpectedStartByte;
        public static int IdIndex;
        public static int StartByteIndex;
        public static int DataLengthIndex;
        public static int MotorId;
        public static int BmsId;
        public static int GpsId;
        public static int BuffSize;
        public static int MpptId;
        public static int DebugId;
        public static int AckId;


        public static readonly ConcurrentQueue<byte> RxByteQueue = new ConcurrentQueue<byte>();


        public static readonly ObservableCollection<Motor> MotorCollection = new ObservableCollection<Motor>();
        public static readonly ObservableCollection<MPPT> MpptCollection = new ObservableCollection<MPPT>();
        public static readonly ObservableCollection<Bms> BmsCollection = new ObservableCollection<Bms>();
        public static readonly ObservableCollection<Gps> GpsCollection = new ObservableCollection<Gps>();
        public static readonly ObservableCollection<Error> ErrorCollection = new ObservableCollection<Error>();
        public static readonly ObservableCollection<Debug> DebugCollection = new ObservableCollection<Debug>();
        public static readonly ObservableCollection<Message> MessageCollection = new ObservableCollection<Message>();

        public static MotorValidator MotorValidation = new MotorValidator();
        public static BmsValidator BmsValidation = new BmsValidator();
        public static MpptValidator MpptValidation = new MpptValidator();
        public static GpsValidator GpsValidation = new GpsValidator();

        public static void Init()
        {
            ExpectedStartByte = int.Parse(ConfigurationManager.AppSettings.Get("ExpectedStartByte"));
            IdIndex = int.Parse(ConfigurationManager.AppSettings.Get("IdIndex"));
            StartByteIndex = int.Parse(ConfigurationManager.AppSettings.Get("StartByteIndex"));
            DataLengthIndex = int.Parse(ConfigurationManager.AppSettings.Get("DataLengthIndex"));
            MotorId = int.Parse(ConfigurationManager.AppSettings.Get("MotorId"));
            BmsId = int.Parse(ConfigurationManager.AppSettings.Get("BmsId"));
            GpsId = int.Parse(ConfigurationManager.AppSettings.Get("GpsId"));
            BuffSize = int.Parse(ConfigurationManager.AppSettings.Get("BuffSize"));
            MpptId = int.Parse(ConfigurationManager.AppSettings.Get("MpptId"));
            DebugId = int.Parse(ConfigurationManager.AppSettings.Get("DebugId"));
            AckId = int.Parse(ConfigurationManager.AppSettings.Get("AckId"));
        }
    }
}