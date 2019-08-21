using System;
using System.Globalization;
using System.Reflection;
using TelemetryDependencies.Models;
using TelemetryDependencies.Structs;

namespace TelemetryConsole.Database
{
    public partial class TelemetryControl
    {
        public static void DatabaseParser<T>(T dataStruct)
        {
            try
            {
                if (typeof(T) == typeof(BmsStruct))
                {
                    BmsStruct bMsStruct = (BmsStruct) (object) dataStruct;
                    Bms bms = new Bms
                    {
                        MinVolt = bMsStruct.MinVolt,
                        MinVoltId = bMsStruct.MinVoltID,
                        MaxVolt = bMsStruct.MaxVolt,
                        MaxVoltId = bMsStruct.MaxVoltID,
                        Volt = bMsStruct.Volt,
                        Current = bMsStruct.Current,
                        Status = (int) bMsStruct.Status,
                        Soc = bMsStruct.SOC,
                        MinTemp = bMsStruct.MinTemp,
                        MinTempId = bMsStruct.MinTempID,
                        MaxTemp = bMsStruct.MaxTemp,
                        MaxTempId = bMsStruct.MaxTempID,
                        FWVersion = bMsStruct.FWVersion,
                        CycleTime = bMsStruct.CycleTime,
                        MCUTemp = bMsStruct.MCUTemp,
                        RoundtripTm = bMsStruct.RoundtripTm,
                        Time = Time(bMsStruct.TimeStamp)
                    };
                    if (BmsValidation.Validate(bms).IsValid) BmsCollection.Add(bms);
                }

                if (typeof(T) == typeof(MotorStruct))
                {
                    MotorStruct motorStruct = (MotorStruct) (object) dataStruct;
                    Motor motor = new Motor
                    {
                        MotorCurrent = motorStruct.MotorCurrent,
                        MotorDriveMode = motorStruct.MotorDriveMode,
                        MotorRpm = motorStruct.MotorRpm,
                        BatteryCurrent = motorStruct.BatteryCurrent,
                        BatteryCurrentDir = motorStruct.BatteryCurrentDir,
                        MotorCurrentDir = motorStruct.MotorCurrentDir,
                        OutputDuty = motorStruct.OutputDuty,
                        OutputDutyType = motorStruct.OutputDutyType,
                        BatteryVoltage = motorStruct.BatteryVoltage,
                        FailModeInfo = motorStruct.FailModeInfo,
                        FailModeInfo2 = motorStruct.FailModeInfo2,
                        PresentCorePos = motorStruct.PresentCorePos,
                        Gear = motorStruct.Gear,
                        TempControl = motorStruct.TempControl,
                        TempMotor = motorStruct.TempMotor,
                        Time = Time(motorStruct.TimeStamp)
                    };
                    if (MotorValidation.Validate(motor).IsValid) MotorCollection.Add(motor);
                }

                if (typeof(T) == typeof(GpsStruct))
                {
                    GpsStruct gpsStruct = (GpsStruct) (object) dataStruct;
                    GpsCollection.Add(new Gps
                    {
                        Lat = (double) gpsStruct.latitude / 100000,
                        Long = (double) gpsStruct.longitude / 100000,
                        Alt = (double) gpsStruct.altitude / 10,
                        Speed = (double) gpsStruct.speed / 1000 * 3.6,
                        Gpsfix = gpsStruct.gps_fix,
                        Dist = gpsStruct.distance,
                        Tdist = gpsStruct.total_distance,
                        Accx = gpsStruct.x_acc,
                        Accy = gpsStruct.y_acc,
                        Accz = gpsStruct.z_acc,
                        Gyrx = gpsStruct.x_gyro,
                        Gyry = gpsStruct.y_gyro,
                        Gyrz = gpsStruct.z_gyro,
                        TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                }

                if (typeof(T) == typeof(DebugStruct))
                {
                    DebugStruct debugStruct = (DebugStruct) (object) dataStruct;
                    Console.WriteLine("Signal Strength: " + debugStruct.rssi);
                    DebugCollection.Add(new Debug
                    {
                        ExceptionSource = "rssi",
                        Message = debugStruct.rssi.ToString(),
                        Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                }

                if (typeof(T) == typeof(MpptStruct))
                {
                    MpptStruct mpptStruct = (MpptStruct) (object) dataStruct;
                    int i = 0;
                    foreach (FieldInfo field in typeof(MpptStruct).GetFields())
                    {
                        i++;
                        MpptFrameStruct mpptFrameStruct = (MpptFrameStruct) field.GetValue(mpptStruct);
                        MpptCollection.Add(new MPPT
                        {
                            DeviceId = i,
                            InputCurrent = (int) mpptFrameStruct.inputCurrent,
                            InputVoltage = (int) mpptFrameStruct.inputVoltage,
                            OutputVoltage = (int) mpptFrameStruct.outputVoltage,
                            OutputCurrent = (int) mpptFrameStruct.outputCurrent,
                            ControllerTemp = (int) mpptFrameStruct.controllerTemp,
                            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                        });
                    }
                }

                if (typeof(T) == typeof(AckStruct))
                {
                    AckStruct ackStruct = (AckStruct) (object) dataStruct;
                    MessageCollection.Add(new Message
                    {
                        Prefix = "$ACK",
                        MessageId = ackStruct.ackId,
                        Length = 1,
                        Text = "ACK",
                        DateTime = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string Time(ulong time)
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
    }
}