using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GpsStruct
    {
        [MarshalAs(UnmanagedType.I4)] public int latitude;

        [MarshalAs(UnmanagedType.I4)] public int longitude;

        [MarshalAs(UnmanagedType.I4)] public int altitude;

        [MarshalAs(UnmanagedType.U4)] public int speed;

        [MarshalAs(UnmanagedType.U4)] public int heading_vehicle;

        [MarshalAs(UnmanagedType.I2)] public byte gps_fix;

        [MarshalAs(UnmanagedType.U4)] public int distance;

        [MarshalAs(UnmanagedType.U4)] public int total_distance;

        [MarshalAs(UnmanagedType.I4)] public int x_acc;

        [MarshalAs(UnmanagedType.I4)] public int y_acc;

        [MarshalAs(UnmanagedType.I4)] public int z_acc;

        [MarshalAs(UnmanagedType.I4)] public int x_gyro;

        [MarshalAs(UnmanagedType.I4)] public int y_gyro;

        [MarshalAs(UnmanagedType.I4)] public int z_gyro;
        [MarshalAs(UnmanagedType.U8)] public ulong TimeStamp;
    }
}