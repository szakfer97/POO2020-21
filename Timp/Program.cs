using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu timpul");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());
                int d = int.Parse(Console.ReadLine());
                int e = int.Parse(Console.ReadLine());
                int f = int.Parse(Console.ReadLine());
                int g = int.Parse(Console.ReadLine());
                int h = int.Parse(Console.ReadLine());
                Timp t1 = new Timp(a, b, c, d);
                Timp t2 = new Timp(e, f, g, h);
                Timp t3 = t1 + t2;
                Timp t4 = t1 - t2;
                Console.WriteLine("Suma este " + t3.Ore + ":" + t3.Minute + ":" + t3.Secunde + ":" + t3.Sutimi);
                Console.WriteLine("Diferenta este " + t4.Ore + ":" + t4.Minute + ":" + t4.Secunde + ":" + t4.Sutimi);
                Console.ReadKey();
            }
            catch (Exception i)
            {
                Console.WriteLine($" {i.Message}");
            }
        }
    }
    class Timp
    {
        public int Ore { get; set; }
        public int Minute { get; set; }
        public int Secunde { get; set; }
        public int Sutimi { get; set; }
        public Timp(int Ore, int Minute)
        {
            this.Ore = Ore;
            this.Minute = Minute;
        }
        public Timp(int Ore, int Minute, int Secunde)
        {
            this.Ore = Ore;
            this.Minute = Minute;
            this.Secunde = Secunde;
        }
        public Timp(int Ore, int Minute, int Secunde, int Sutimi)
        {
            this.Ore = Ore;
            this.Minute = Minute;
            this.Secunde = Secunde;
            this.Sutimi = Sutimi;
        }
        public Timp(string timp)
        {
            var valori = timp.Split(';').Select(Int32.Parse).ToList();
            Ore = valori[0];
            Minute = valori[1];
            Secunde = valori[2];
            Sutimi = valori[3];
        }
        public static int SutimiinMilisecunde(int Sutimi)
        {
            return Sutimi * 10;
        }
        public static int SecundeinMilisecunde(int Secunde)
        {
            return Secunde * 1000;
        }
        public static int MinuteinMilisecunde(int Minute)
        {
            int MinuteinMilisecunde = Minute * 60;
            return SecundeinMilisecunde(MinuteinMilisecunde);
        }
        public static int OreinMilisecunde(int Ore)
        {
            int OreinMinute = Ore * 60;
            return MinuteinMilisecunde(OreinMinute);
        }
        public static int TimpulinMilisecunde(Timp timp)
        {
            return OreinMilisecunde(timp.Ore) +
                   MinuteinMilisecunde(timp.Minute) +
                   SecundeinMilisecunde(timp.Secunde) +
                   SutimiinMilisecunde(timp.Sutimi);
        }
        public static Timp MilisecundeinTimp(int n)
        {
            n /= 10;
            int Sutimi = n % 100;
            n /= 100;
            int Secunde = n % 60;
            n /= 60;
            int Minute = n % 60;
            n /= 60;
            int Ore = n;
            return new Timp(Ore, Minute, Secunde, Sutimi);
        }
        public static Timp operator +(Timp T1, Timp T2)
        {
            int TotalMilisecunde = TimpulinMilisecunde(T1) + TimpulinMilisecunde(T2);
            return MilisecundeinTimp(TotalMilisecunde);
        }
        public static Timp operator -(Timp T1, Timp T2)
        {
            int TotalMilisecunde = TimpulinMilisecunde(T1) - TimpulinMilisecunde(T2);
            return MilisecundeinTimp(TotalMilisecunde);
        }
        public static bool operator ==(Timp T1, Timp T2)
        {
            return TimpulinMilisecunde(T1) == TimpulinMilisecunde(T2);
        }
        public static bool operator !=(Timp T1, Timp T2)
        {
            return TimpulinMilisecunde(T1) != TimpulinMilisecunde(T2);
        }
        public static bool operator >(Timp T1, Timp T2)
        {
            return TimpulinMilisecunde(T1) > TimpulinMilisecunde(T2);
        }
        public static bool operator <(Timp T1, Timp T2)
        {
            return TimpulinMilisecunde(T1) < TimpulinMilisecunde(T2);
        }
        public static bool operator >=(Timp T1, Timp T2)
        {
            return TimpulinMilisecunde(T1) >= TimpulinMilisecunde(T2);
        }
        public static bool operator <=(Timp T1, Timp T2)
        {
            return TimpulinMilisecunde(T1) <= TimpulinMilisecunde(T2);
        }
    }
}
