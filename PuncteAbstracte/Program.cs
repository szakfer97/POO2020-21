using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuncteAbstracte
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu puncte abstracte");
                Punct p1 = new Punct(PuncteAbstracte.ReprezentarePunct.Polar, 10, 45);
                Console.WriteLine($"Punctul p1 are coordonatele:{p1}");
                Punct p2 = new Punct(PuncteAbstracte.ReprezentarePunct.Dreptunghiular, 10, 45);
                Console.WriteLine($"Punctul p2 are coordonatele:{p2}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
    }
    public abstract class PuncteAbstracte
    {
        public enum ReprezentarePunct
        {
            Polar,
            Dreptunghiular
        }
        public abstract double a { get; set; }
        public abstract double b { get; set; }
        public abstract double r { get; set; }
        public abstract double A { get; set; }
        public void Miscare(double dX, double dY)
        {
            a += dX;
            b += dY;
        }
        public void Rotare(double unghi)
        {
            A += unghi;
        } 
        protected static double RadiusR(double a, double b)
        {
            return Math.Sqrt(a * a + b * b);
        }
        protected static double UnghiA(double a, double b)
        {
            return Math.Atan2(b, a);
        }
        protected static double ARadiusUnghi(double r, double A)
        {
            return r * Math.Cos(A);
        }
        protected static double BRadiusUnghi(double r, double A)
        {
            return r * Math.Sin(A);
        }
        public override string ToString()
        {
            return string.Format($"({a},{b}) : [{r},{A}]");
        }
    }
    public class Punct : PuncteAbstracte
    {
        private double raza;
        private double unghiul;        
        public Punct(ReprezentarePunct PR, double a, double b)
        {
            if (PR == ReprezentarePunct.Polar)
            {
                raza = a;
                unghiul = b;
            }
            if (PR == ReprezentarePunct.Dreptunghiular)
            {
                raza = RadiusR(a, b);
                unghiul = UnghiA(a, b);
            }
        }
        public override double a
        {
            get { return ARadiusUnghi(raza, unghiul); }
            set
            {
                double InitialB = BRadiusUnghi(raza, unghiul);

                unghiul = UnghiA(value, InitialB);
                raza = RadiusR(value, InitialB);
            }
        }
        public override double b
        {
            get { return BRadiusUnghi(raza, unghiul); }
            set
            {
                double InitialA = ARadiusUnghi(raza, unghiul);
                unghiul = UnghiA(InitialA, value);
                raza = RadiusR(InitialA, value);
            }
        }
        public override double r
        {
            get { return raza; }
            set { raza = value; }
        }
        public override double A
        {
            get { return unghiul; }
            set { unghiul = value; }
        }
    }
}
