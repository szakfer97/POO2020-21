using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IForma2D
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu cercuri si patrate");
                Cerc cerc = new Cerc(10.0, "cerc");
                Console.WriteLine(cerc.calcAria());
                Console.WriteLine(cerc.LungimeaFrontierei());
                Patrat patrat = new Patrat(4.0, "patrat");
                Console.WriteLine(patrat.calcAria());
                CuMetoda(patrat);
                CuMetoda(cerc);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
        public static void CuMetoda(IForma2D ID)
        {
            Console.WriteLine($"Aria formei geometrice {ID.Denumire} este:{ID.calcAria()}");
            Console.WriteLine($"Circumferinta formei geometrice {ID.Denumire} este:{ID.LungimeaFrontierei()}");
        }
    }
    interface IForma2D
    {
        double calcAria();
        double LungimeaFrontierei();
        string Denumire
        {
            get;
        }
    }
    class Cerc : IForma2D
    {
        private double raza;
        public string Denumire { get; }
        public double Raza
        {
            get { return raza; }
        }
        public Cerc(double raza, string Denumire)
        {
            this.raza = raza;
            this.Denumire = Denumire;
        }
        public double calcAria()
        {
            return raza * raza * Math.PI;
        }
        public double LungimeaFrontierei()
        {
            return 2 * raza * Math.PI;
        }
    }
    class Patrat : IForma2D
    {
        private double Latime;
        public string Denumire { get; }

        public Patrat()
        {
            Latime = 0;
        }
        public Patrat(double Latime, string Denumire)
        {
            this.Latime = Latime;
            this.Denumire = Denumire;
        }
        public double calcAria()
        {
            return Latime * Latime;
        }
        public double LungimeaFrontierei()
        {
            return 4 * Latime;
        }
    }
}
