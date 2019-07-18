using System;
using System.Globalization;
using TelemetryConsole.Misc;
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
                    var bMsStruct = (BmsStruct) (object) dataStruct;
                    BmsCollection.Add(new Bms
                    {
                        MinVolt = bMsStruct.MinVolt,
                        MinVoltId = bMsStruct.MinVoltID,
                        MaxVolt = bMsStruct.MaxVolt,
                        MaxVoltId = bMsStruct.MaxVoltID,
                        Volt = bMsStruct.Volt,
                        Current = bMsStruct.Current,
                        Status = bMsStruct.Status,
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
                    });
                }

                if (typeof(T) == typeof(MotorStruct))
                {
                    var motorStruct = (MotorStruct) (object) dataStruct;
                    MotorCollection.Add(new Motor
                    {
                        MotorCurrent = motorStruct.MotorCurrent,
                        MotorDriveMode = motorStruct.MotorDriveMode,
                        MotorRPM = motorStruct.MotorRpm,
                        BatteryCurrent = motorStruct.BatteryCurrent,
                        CurrentDirection = motorStruct.BatteryCurrent,
                        OutputDuty = motorStruct.OutputDuty,
                        OutputDutyType = motorStruct.OutputDutyType,
                        BatteryVoltage = motorStruct.BatteryVoltage,
                        FailModeInfo = motorStruct.FailModeInfo,
                        FailModeInfo2 = motorStruct.FailModeInfo2,
                        PresentCorePos = motorStruct.PresentCorePos,
                        TempControl = motorStruct.TempControl,
                        TempMotor = motorStruct.TempMotor,
                        Time = Time(motorStruct.TimeStamp)
                    });
                }

                if (typeof(T) == typeof(MotorStructOld))
                {
                    var motorStruct = (MotorStructOld) (object) dataStruct;
                    MotorCollection.Add(new Motor
                    {
                        MotorCurrent = motorStruct.MotorCurrent,
                        MotorDriveMode = motorStruct.MotorDriveMode,
                        MotorRPM = motorStruct.MotorRPM,
                        BatteryCurrent = motorStruct.BatteryCurrent,
                        CurrentDirection = motorStruct.BatteryCurrentDir2,
                        OutputDuty = motorStruct.OutputDuty,
                        OutputDutyType = motorStruct.OutputDutyType,
                        BatteryVoltage = motorStruct.BatteryVoltage,
                        FailModeInfo = motorStruct.FailModeInfo1,
                        FailModeInfo2 = motorStruct.FailModeInfo2,
                        PresentCorePos = motorStruct.PresentCorePos,
                        TempControl = motorStruct.TempControl,
                        TempMotor = motorStruct.TempMotor,
                        Time = Time(motorStruct.Time)
                    });
                }

                if (typeof(T) == typeof(GpsStruct))
                {
                    var gpsStruct = (GpsStruct) (object) dataStruct;
                    GpsCollection.Add(new Gps
                    {
                        LAT = (double)gpsStruct.latitude/100000,
                        LONG = (double)gpsStruct.longitude/100000,
                        ALT = (double)gpsStruct.altitude/10,
                        SPEED = gpsStruct.speed,
                        GPSFIX = gpsStruct.gps_fix,
                        DIST = gpsStruct.distance,
                        TDIST = gpsStruct.total_distance,
                        ACCX = gpsStruct.x_acc,
                        ACCY = gpsStruct.y_acc,
                        ACCZ = gpsStruct.z_acc,
                        GYRX = gpsStruct.x_gyro,
                        GYRY = gpsStruct.y_gyro,
                        GYRZ = gpsStruct.z_gyro,
                        DeviceName = 0,
                        TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                }
            }
            catch (Exception ex)
            {
                Extensions.PrintProperties(ex);
            }
        }

        private static string Time(ulong time)
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
    }
}