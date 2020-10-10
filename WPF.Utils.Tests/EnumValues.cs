﻿using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// Last changed 2020-10-10.

namespace WPF.Utils.Tests
{
    /// <summary>
    /// Enumeration of values.
    /// </summary>
    public static class EnumValues
    {
        /// <summary>
        /// List of bool values.
        /// </summary>
        /// <returns></returns>
        public static List<bool> GetBool()
        {
            return new List<bool>() { false, true };
        }

        /// <summary>
        /// List of string values.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetString()
        {
            return new List<string>() { null, "", string.Empty };
        }

        /// <summary>
        /// List of ushort values.
        /// </summary>
        /// <returns></returns>
        public static List<ushort> GetUshort()
        {
            return new List<ushort>() { ushort.MinValue, 1, ushort.MaxValue / 2, ushort.MaxValue };
        }

        /// <summary>
        /// List of progress values.
        /// </summary>
        /// <returns></returns>
        public static List<ushort> GetProgress()
        {
            return new List<ushort>() { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        }

        /// <summary>
        /// List of short values.
        /// </summary>
        /// <returns></returns>
        public static List<short> GetShort()
        {
            return new List<short>() { short.MinValue, 1, short.MaxValue / 2, short.MaxValue };
        }

        /// <summary>
        /// List of uint values.
        /// </summary>
        /// <returns></returns>
        public static List<uint> GetUint()
        {
            return new List<uint>() { uint.MinValue, 1, uint.MaxValue / 2, uint.MaxValue };
        }

        /// <summary>
        /// List of int values.
        /// </summary>
        /// <returns></returns>
        public static List<int> GetInt()
        {
            return new List<int>() { int.MinValue, 1, int.MaxValue / 2, int.MaxValue };
        }

        /// <summary>
        /// String value.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AsString(this string str)
        {
            return str == null ? "<null>" : str == "" ? "<empty>" : str;
        }
    }
}