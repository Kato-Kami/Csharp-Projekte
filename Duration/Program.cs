using System;
namespace Klasse_Duration
{
    public class Duration
    {
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }

        // Konstruktor mit Werten für die Anzahl der Tage, Stunden und Minuten
        public Duration(int days, int hours, int minutes)
        {
            int totalMinutes = days * 24 * 60 + hours * 60 + minutes;

            this.Days = ((totalMinutes / 24) / 60);
            this.Minutes = totalMinutes % 60;
            this.Hours = (totalMinutes - ((this.Days * 24 * 60) + this.Minutes)) / 60;
        }

        // Ausgabe des oben erschafften Konstruktors
        public override string ToString()
        {
            return $"Es dauert: {this.Days} Tage, {this.Hours} Stunden und {this.Minutes} Minuten.";
        }

        // Implementierung eines Additionsoperators
        public static Duration operator +(Duration x, Duration y)
        {
            int totalMinutes = TimeToMinutes(x) + TimeToMinutes(y);

            return MinutesToTime(totalMinutes);
        }

        // Subtraktionsoperator
        public static Duration operator -(Duration x, Duration y)
        {
            int timeX = TimeToMinutes(x);
            int timeY = TimeToMinutes(y);

            if (timeX > timeY)
            {

                return MinutesToTime(timeX - timeY);

            }
            else
            {
                return MinutesToTime(timeY - timeX);
            }
        }

        // Vergleichsoperator "Kleiner als"
        public static bool operator <(Duration x, Duration y)
        {
            return (int)x < (int)y;
        }

        // Vergleichsoperator "Größer als"
        public static bool operator >(Duration x, Duration y)
        {
            return (int)x > (int)y;
        }

        // Vergleichsoperator "Kleiner gleich"
        public static bool operator <=(Duration x, Duration y)
        {
            return (int)x <= (int)y;
        }

        // Vergleichsoperator "Größer als"
        public static bool operator >=(Duration x, Duration y)
        {
            return (int)x >= (int)y;
        }

        // Umwandlung der Duration in Integer-Werte
        public static explicit operator int(Duration x)
        {
            return (x.Days * 24 * 60 + x.Hours * 60 + x.Minutes) * 60;
        }

        public static int TimeToMinutes(Duration x)
        {
            return x.Days * 24 * 60 + x.Hours * 60 + x.Minutes;
        }

        public static Duration MinutesToTime(int minutes)
        {
            int days = (minutes / 24) / 60;
            int min = minutes % 60;
            int hours = (minutes - ((days * 24 * 60) + min)) / 60;

            return new Duration(days, hours, min);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Duration d1 = new Duration(1, 30, 50);
            Console.WriteLine($"{d1} Das ist gleich {(int)d1} Sekunden");

            Duration d2 = new Duration(2, 3, 4);
            Console.WriteLine(d1 + d2);
            Console.WriteLine(d2 - d1);

            Console.WriteLine(d1 < d2);
            Console.WriteLine(d1 > d2);

            Duration d3 = new Duration(2, 3, 4);

            Console.WriteLine(d2 <= d3);
            Console.WriteLine(d2 >= d3);
        }
    }
}
