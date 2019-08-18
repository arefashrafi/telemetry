using System.Runtime.InteropServices;

namespace TelemetryDependencies.Structs
{
    [StructLayout(LayoutKind.Explicit,Size = 56)]
    public struct MpptStruct
    {
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(0)] public mppt_frame_struct mppt1;
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(6)] public mppt_frame_struct mppt2;
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(12)] public mppt_frame_struct mppt3;
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(18)] public mppt_frame_struct mppt4;
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(24)] public mppt_frame_struct mppt5;
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(30)] public mppt_frame_struct mppt6;
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(36)] public mppt_frame_struct mppt7;
        [MarshalAs(UnmanagedType.Struct)][FieldOffset(42)] public mppt_frame_struct mppt8;
        [MarshalAs(UnmanagedType.U8)][FieldOffset(48)] public ulong TimeStamp;
    }
}