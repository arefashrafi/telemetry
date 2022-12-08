﻿using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TelemetryConsole.Misc
{
    public static class Extensions
    {
        public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            T data;
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                data = (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }

            return data;
        }

        // create a subset from a range of indices
        public static T[] RangeSubset<T>(this T[] array, int startIndex, int length)
        {
            try
            {
                var subset = new T[length];
                Array.Copy(array, startIndex, subset, 0, length);
                return subset;
            }
            catch
            {
                return null;
            }
        }

        public static void PrintProperties<T>(T myObj)
        {
            foreach (PropertyInfo prop in myObj.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + ": " + prop.GetValue(myObj, null));
            }

            foreach (FieldInfo field in myObj.GetType().GetFields())
            {
                Console.WriteLine(field.Name + ": " + field.GetValue(myObj));
            }
        }
    }
}