using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 56)]
    public struct MpptStruct
    {
        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(0)]
        public MpptFrameStruct mppt1;

        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(6)]
        public MpptFrameStruct mppt2;

        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(12)]
        public MpptFrameStruct mppt3;

        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(18)]
        public MpptFrameStruct mppt4;

        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(24)]
        public MpptFrameStruct mppt5;

        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(30)]
        public MpptFrameStruct mppt6;

        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(36)]
        public MpptFrameStruct mppt7;

        [MarshalAs(UnmanagedType.Struct)] [FieldOffset(42)]
        public MpptFrameStruct mppt8;

        [MarshalAs(UnmanagedType.U8)] [FieldOffset(48)]
        public ulong TimeStamp;
    }
}