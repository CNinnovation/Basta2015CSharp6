using System;
using System.Globalization;
using static System.Console;

namespace StringInterpolationSample
{
    public static class StringExtensions
    {
        public static void DisplayString(this FormattableString s)
        {
            WriteLine("display string");
            WriteLine($"Format: {s.Format}");
            WriteLine($"Argument count: {s.ArgumentCount}");
            
            WriteLine(s.ToString());
            WriteLine();
        }

        public static string Spanish(this FormattableString s) =>
            s.ToString(new CultureInfo("es-ES"));
    }


    public class Program
    {
        public void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            var today = DateTime.Today;
            WriteLine($"heute ist: {today:D}");
            FormattableString s = $"heute ist: {today:d} und {today:D}";
            WriteLine(FormattableString.Invariant($"heute ist: {today:d}"));
            WriteLine(s.Spanish());
            s.DisplayString();
        }
    }
}
