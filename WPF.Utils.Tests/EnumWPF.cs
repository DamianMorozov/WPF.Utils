using System.Collections.Generic;
using System.Windows.Media;
// ReSharper disable UnusedMember.Global
// Last changed 2020-10-10.

namespace WPF.Utils.Tests
{
    /// <summary>
    /// Enumeration of values.
    /// </summary>
    public static class EnumWPF
    {
        /// <summary>
        /// List of Color values.
        /// </summary>
        /// <returns></returns>
        public static List<Color> GetColors()
        {
            return new List<Color>() { Colors.White, Colors.Black, Colors.Blue, Colors.Gray, Colors.Green, Colors.Red };
        }

        /// <summary>
        /// List of Brush values.
        /// </summary>
        /// <returns></returns>
        public static List<Brush> GetBrush()
        {
            return new List<Brush>() { Brushes.Transparent, Brushes.White, Brushes.Black, Brushes.Blue, Brushes.Gray, Brushes.Green, Brushes.Red };
        }
    }
}
