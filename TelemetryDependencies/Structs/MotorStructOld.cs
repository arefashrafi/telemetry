using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MotorStructOld
    {
        [MarshalAs(UnmanagedType.U2)] public ushort BatteryVoltage;

        [MarshalAs(UnmanagedType.U2)] public ushort BatteryCurrent;

        [MarshalAs(UnmanagedType.U1)] public byte BatteryCurrentDir;

        [MarshalAs(UnmanagedType.U2)] public ushort MotorCurrent;

        [MarshalAs(UnmanagedType.U1)] public byte BatteryCurrentDir2;

        [MarshalAs(UnmanagedType.U1)] public byte TempControl;

        [MarshalAs(UnmanagedType.U1)] public byte TempMotor;

        [MarshalAs(UnmanagedType.U2)] public ushort MotorRPM;

        [MarshalAs(UnmanagedType.U2)] public ushort OutputDuty;

        [MarshalAs(UnmanagedType.U1)] public byte OutputDutyType;

        [MarshalAs(UnmanagedType.U1)] public byte MotorDriveMode;

        [MarshalAs(UnmanagedType.U1)] public byte FailModeInfo1;

        [MarshalAs(UnmanagedType.U1)] public byte TempErrLevel;

        [MarshalAs(UnmanagedType.U1)] public byte PresentCorePos;

        [MarshalAs(UnmanagedType.U1)] public byte FailModeInfo2;

        [MarshalAs(UnmanagedType.U8)] public ulong Time;
    }
}