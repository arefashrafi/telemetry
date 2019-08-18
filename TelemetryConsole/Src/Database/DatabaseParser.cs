using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using Telemetry.App;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;
using TelemetryDependencies.Structs;

namespace TelemetryConsole.Database
{
    public partial class TelemetryControl
    {
        private static int _countcorrect = 0;

        public static void DatabaseParser<T>(T dataStruct)
        {
            try
            {
                if (typeof(T) == typeof(BmsStruct))
                {
                    BmsStruct bMsStruct = (BmsStruct) (object) dataStruct;
                    var bms = new Bms
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
                    if (BmsValidation.Validate(bms).IsValid)
                    {
                        BmsCollection.Add(bms);
                    }
                }

                if (typeof(T) == typeof(MotorStruct))
                {
                    MotorStruct motorStruct = (MotorStruct) (object) dataStruct;
                    var motor = new Motor
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
                    if (MotorValidation.Validate(motor).IsValid)
                    {
                        MotorCollection.Add(motor);
                    }
                }

                if (typeof(T) == typeof(GpsStruct))
                {
                    GpsStruct gpsStruct = (GpsStruct) (object) dataStruct;
                    GpsCollection.Add(new Gps
                    {
                        LAT = (double) gpsStruct.latitude / 100000,
                        LONG = (double) gpsStruct.longitude / 100000,
                        ALT = (double) gpsStruct.altitude / 10,
                        SPEED = ((double) gpsStruct.speed / 1000) * 3.6,
                        GPSFIX = gpsStruct.gps_fix,
                        DIST = gpsStruct.distance,
                        TDIST = gpsStruct.total_distance,
                        ACCX = gpsStruct.x_acc,
                        ACCY = gpsStruct.y_acc,
                        ACCZ = gpsStruct.z_acc,
                        GYRX = gpsStruct.x_gyro,
                        GYRY = gpsStruct.y_gyro,
                        GYRZ = gpsStruct.z_gyro,
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
                    foreach (var field in typeof(MpptStruct).GetFields())
                    {
                        i++;
                        mppt_frame_struct mpptFrameStruct = (mppt_frame_struct) field.GetValue(mpptStruct);
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