using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu numere rationale");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());
                int d = int.Parse(Console.ReadLine());
                int x = int.Parse(Console.ReadLine());
                Rationale r1 = new Rationale(a, b);
                Rationale r2 = new Rationale(c, d);
                Console.WriteLine(r1 + r2);
                Console.WriteLine(r1 - r2);
                Console.WriteLine(r1 * r2);
                Console.WriteLine(r1 / r2);
                Console.WriteLine(r1 ^ x);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
    }
    public class Rationale
    {
        public int Numarator;
        public int Numitor;
        public override string ToString()
        {
            return this.Numarator + "/" + this.Numitor;
        }
        public Rationale()
        {
            return;
        }
        public Rationale(int Numarator)
        {
            this.Numarator = Numarator;
            this.Numitor = 1;
        }
        public Rationale(int Numarator, int Numitor)
        {
            this.Numarator = Numarator;
            this.Numitor = Numitor;
            Simplificare();
        }
        private int CMMDC(int x, int y)
        {
            return y == 0 ? x : CMMDC(y, x % y);
        }
        public void Simplificare()
        {
            int cmmdc = CMMDC(this.Numarator, this.Numitor);
            this.Numarator /= cmmdc;
            this.Numitor /= cmmdc;
        }
        private double Valoare()
        {
            return (double)this.Numarator / (double)this.Numitor;
        }
        public static Rationale operator +(Rationale x, Rationale y)
        {
            return new Rationale(x.Numarator * y.Numitor + x.Numitor * y.Numarator, x.Numitor * y.Numitor);
        }
        public static Rationale operator -(Rationale x, Rationale y)
        {
            y.Numarator *= -1;
            return x + y;
        }
        public static Rationale operator *(Rationale x, Rationale y)
        {
            return new Rationale(x.Numarator * y.Numarator, x.Numitor * y.Numitor);
        }
        public static Rationale operator /(Rationale x, Rationale y)
        {
            return x * new Rationale(y.Numitor, y.Numarator);
        }
        public static Rationale operator ^(Rationale x, int n)
        {
            Rationale rezultat = x;
            for (int i = 0; i < n - 1; i++)
            {
                rezultat *= x;
            }
            return rezultat;
        }
        public static bool operator <(Rationale x, Rationale y)
        {
            return x.Valoare() < y.Valoare();
        }
        public static bool operator >(Rationale x, Rationale y)
        {
            return x.Valoare() > y.Valoare();
        }
        public static bool operator <=(Rationale x, Rationale y)
        {
            return x.Valoare() <= y.Valoare();
        }
        public static bool operator >=(Rationale x, Rationale y)
        {
            return x.Valoare() >= y.Valoare();
        }
        public static bool operator ==(Rationale x, Rationale y)
        {
            return x.Valoare() == y.Valoare();
        }
        public static bool operator !=(Rationale x, Rationale y)
        {
            return x.Valoare() != y.Valoare();
        }
    }
}
