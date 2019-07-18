using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DebugStruct
    {
        [MarshalAs(UnmanagedType.U1)] public byte rssi;
    }
}