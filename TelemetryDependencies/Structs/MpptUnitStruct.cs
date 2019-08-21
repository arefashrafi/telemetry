using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 6)]
    public struct MpptFrameStruct
    {
        [MarshalAs(UnmanagedType.U1)] [FieldOffset(0)]
        public uint inputCurrent;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(1)]
        public uint inputVoltage;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(2)]
        public uint outputCurrent;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(3)]
        public uint outputVoltage;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(4)]
        public uint mosfetTemp;

        [MarshalAs(UnmanagedType.U1)] [FieldOffset(5)]
        public uint controllerTemp;
    }
}