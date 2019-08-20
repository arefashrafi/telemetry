using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 53)]
    public struct GpsStruct
    {
        [MarshalAs(UnmanagedType.I4)] [FieldOffset(0)]
        public int latitude;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(4)]
        public int longitude;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(8)]
        public uint speed;

        [MarshalAs(UnmanagedType.U4)] [FieldOffset(12)]
        public uint course;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(16)]
        public int altitude;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(20)]
        public byte gps_fix;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(21)]
        public int distance;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(25)]
        public int total_distance;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(29)]
        public int x_acc;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(33)]
        public int y_acc;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(37)]
        public int z_acc;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(41)]
        public int x_gyro;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(45)]
        public int y_gyro;

        [MarshalAs(UnmanagedType.I4)] [FieldOffset(49)]
        public int z_gyro;
    }
}