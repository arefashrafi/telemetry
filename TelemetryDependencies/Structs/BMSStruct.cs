using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BmsStruct
    {
        [MarshalAs(UnmanagedType.U2)] public ushort MinVolt;

        [MarshalAs(UnmanagedType.U1)] public byte MinVoltID;

        [MarshalAs(UnmanagedType.U2)] public ushort MaxVolt;

        [MarshalAs(UnmanagedType.U1)] public byte MaxVoltID;

        [MarshalAs(UnmanagedType.U2)] public ushort Volt;

        [MarshalAs(UnmanagedType.I2)] public short Current;

        [MarshalAs(UnmanagedType.U4)] public uint Status;

        [MarshalAs(UnmanagedType.U2)] public ushort SOC;

        [MarshalAs(UnmanagedType.I2)] public short MinTemp;

        [MarshalAs(UnmanagedType.U1)] public byte MinTempID;

        [MarshalAs(UnmanagedType.I2)] public short MaxTemp;

        [MarshalAs(UnmanagedType.U1)] public byte MaxTempID;

        [MarshalAs(UnmanagedType.U2)] public ushort FWVersion;

        [MarshalAs(UnmanagedType.U2)] public ushort CycleTime;

        [MarshalAs(UnmanagedType.I2)] public short MCUTemp;

        [MarshalAs(UnmanagedType.U2)] public ushort RoundtripTm;

        [MarshalAs(UnmanagedType.U8)] public ulong TimeStamp;
    }
}