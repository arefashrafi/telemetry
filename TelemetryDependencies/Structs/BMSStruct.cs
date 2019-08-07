using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 38)]
    public struct BmsStruct
    {
        [MarshalAs(UnmanagedType.U2)] [FieldOffset(0)]
        public ushort MinVolt;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(2)]
        public byte MinVoltID;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(3)]
        public ushort MaxVolt;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(4)]
        public byte MaxVoltID;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(6)]
        public ushort Volt;

        [MarshalAs(UnmanagedType.I2)] [FieldOffset(8)]
        public short Current;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(12)]
        public uint Status;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(14)]
        public ushort SOC;

        [MarshalAs(UnmanagedType.I2)] [FieldOffset(16)]
        public short MinTemp;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(17)]
        public byte MinTempID;

        [MarshalAs(UnmanagedType.I2)] [FieldOffset(19)]
        public short MaxTemp;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(20)]
        public byte MaxTempID;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(22)]
        public ushort FWVersion;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(24)]
        public ushort CycleTime;

        [MarshalAs(UnmanagedType.I2)] [FieldOffset(26)]
        public short MCUTemp;

        [MarshalAs(UnmanagedType.U2)] [FieldOffset(28)]
        public ushort RoundtripTm;

        [MarshalAs(UnmanagedType.U8)] [FieldOffset(30)]
        public ulong TimeStamp;
    }
}