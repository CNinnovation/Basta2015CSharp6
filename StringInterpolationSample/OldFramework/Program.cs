using System;
using System.Globalization;
using System.Threading;
using static System.Console;

namespace OldFramework
{
    public static class StringExtensions
    {
        public static void DisplayString(this FormattableString s)
        {
            WriteLine($"Format: {s.Format}");
            WriteLine($"Argument count: {s.ArgumentCount}");
        }

        public static string Spanish(this FormattableString s) =>
            s.ToString(new CultureInfo("es-ES"));

    }


    class Program
    {
        static void Main()
        {
            //CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            var today = DateTime.Today;
            WriteLine($"heute ist: {today:D}");
            FormattableString s = $"heute ist: {today:d} und {today:D}";
            WriteLine(FormattableString.Invariant($"heute ist: {today:d}"));
            WriteLine(s.Spanish());
            s.DisplayString();
        }
    }
}
