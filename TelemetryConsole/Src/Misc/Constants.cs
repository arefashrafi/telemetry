using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Configuration;
using TelemetryDependencies.Models;
namespace TelemetryConsole.Src.Misc
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
            try
            { 
                StartByteIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("StartByteIndex"));
                DataLengthIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DataLengthIndex"));
                IdIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("IdIndex"));
                MotorId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MotorId"),16);
                BmsId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BmsId"),16);
                GpsId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("GpsId"),16);
                BuffSize = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BuffSize"),16);
                MpptId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MpptId"),16);
                DebugId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DebugId"),16);
                AckId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("AckId"),16);
                ExpectedStartByte = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ExpectedStartByte"),16);

            }
            catch (Exception e)
            {
                Console.WriteLine(e+ "---------------->>>>>>>> Check App.config for wrong hex");
            }

        }
    }
}