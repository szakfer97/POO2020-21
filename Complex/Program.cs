using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu numere complexe");
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double c = double.Parse(Console.ReadLine());
                double d = double.Parse(Console.ReadLine());
                int x = int.Parse(Console.ReadLine());
                Complexe c1 = new Complexe(a, b);
                Complexe c2 = new Complexe(c, d);
                Console.WriteLine(c1);
                Console.WriteLine(c2);
                Complexe suma = c1.Sum(c2);
                Complexe scad = c1.Scad(c2);
                Complexe multip = c1.Mult(c2);
                Complexe putere = c1.Put(x);
                Console.WriteLine($"Suma este:{suma}");
                Console.WriteLine($"Scaderea este:{scad}");
                Console.WriteLine($"Inmultirea este:{multip}");
                Console.WriteLine($"Ridicarea la putere este:{putere}");
                c1.Trig();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
    }
    public class Complexe
    {
        public double re;
        public double im;
        public Complexe(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public Complexe(double re) : this(re, 0)
        {
            return;
        }
        public Complexe(string v)
        {
            return;
        }
        public double Real
        {
            get
            {
                return re;
            }
            set
            {
                re = value;
            }
        }
        public double Imag
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }
        public double Modul
        {
            get
            {
                double rez = Math.Sqrt(re * re + im * im);
                return rez;
            }
        }
        public double Argument
        {
            get
            {
                double rez = Math.Atan(im / re);
                return rez;
            }
        }
        public Complexe Complement
        {
            get
            {
                return new Complexe(re, -im);
            }
        }
        public static Complexe operator +(Complexe x, Complexe y)
        {
            return new Complexe(x.re + y.re, x.im + y.im);
        }
        public static Complexe operator -(Complexe x, Complexe y)
        {
            return new Complexe(x.re - y.re, x.im - y.im);
        }
        public static Complexe operator *(Complexe x, Complexe y)
        {
            return new Complexe((x.re * y.re) - (x.im * y.im), (x.im * y.re) + (x.re * y.im));
        }
        public static Complexe operator ^(Complexe x, int p)
        {
            Complexe rez = new Complexe(1);
            if (p == 0)
                return new Complexe(1);
            if (p == 1)
                return x;
            for (int i = 0; i < p; i++)
                rez = rez * x;
            return rez;
        }
        public override string ToString()
        {
            if (re == 0)
                return "(" + im.ToString() + "i" + ")";
            if (im == 0)
                return "(" + re.ToString() + ")";
            if (im < 0)
                return "(" + re.ToString() + im.ToString() + "i" + ")";
            return "(" + re.ToString() + "+" + im.ToString() + "i" + ")";
        }
        public Complexe Sum(Complexe c2)
        {
            Complexe rezultat = new Complexe(c2.re + re, c2.im + im);
            return rezultat;
        }
        public Complexe Scad(Complexe c2)
        {
            Complexe rezultat = new Complexe(re - c2.re, im - c2.im);
            return rezultat;
        }
        public Complexe Mult(Complexe c2)
        {
            Complexe rezultat = new Complexe((re * c2.re) - (im * c2.im), (im * c2.re) + (re * c2.im));
            return rezultat;
        }
        public virtual Complexe Put(int put)
        {
            Complexe x = new Complexe(re, im);
            Complexe rez = new Complexe(1);
            if (put == 0)
                return new Complexe(1);
            if (put == 1)
                return x;
            for (int i = 0; i < put; i++)
                rez = rez * x;
            return rez;
        }
        public void Trig()
        {
            double raza = Math.Sqrt(this.re * this.re + this.im * this.im);
            double thetainradiani = Math.Atan2(this.im, this.re);
            double thetaingrade = (180 / Math.PI) * thetainradiani;
            Console.Write($"Forma trigonometrica:{String.Format($"{raza}")}");
            Console.Write($" * (cos { String.Format($"{thetaingrade}")}° + i * sin { String.Format($"{thetaingrade}")}°)");
        }
    }
}
