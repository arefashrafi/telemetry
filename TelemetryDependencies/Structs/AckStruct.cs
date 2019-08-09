using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct AckStruct
    {
        [MarshalAs(UnmanagedType.U1)] [FieldOffset(0)]
        public byte ackId;
    }
}