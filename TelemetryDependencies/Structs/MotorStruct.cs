using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 29)]
    public struct MotorStruct
    {
        [MarshalAs(UnmanagedType.U2)] [FieldOffset(0)]
        public ushort BatteryVoltage;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(2)]
        public ushort BatteryCurrent;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(4)]
        public byte BatteryCurrentDir;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(5)]
        public ushort MotorCurrent;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(7)]
        public byte MotorCurrentDir;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(8)]
        public byte TempControl;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(9)]
        public byte TempMotor;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(10)]
        public ushort MotorRpm;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(12)]
        public ushort OutputDuty;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(14)]
        public byte OutputDutyType;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(15)]
        public byte MotorDriveMode;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(16)]
        public byte FailModeInfo;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(17)]
        public byte TempErrLevel;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(18)]
        public byte PresentCorePos;
        
        [MarshalAs(UnmanagedType.U1)] [FieldOffset(19)]
        public byte Gear;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(20)]
        public byte FailModeInfo2;

        [MarshalAs(UnmanagedType.U8)] [FieldOffset(21)]
        public ulong TimeStamp;
    }
}