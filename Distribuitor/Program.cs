using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuitor
{
    public delegate void Iterare(int n);
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program functioneaza ca un distribuitor");
                Distribuitor dist = new Distribuitor();
                AbonamentA abonA = new AbonamentA();
                AbonamentB abonB = new AbonamentB();
                dist.Eveniment += ManipulareEv;
                dist.Eveniment += abonA.AAbonManipulare;
                dist.Eveniment += abonB.BAbonManipulare;
                int x = int.Parse(Console.ReadLine());
                dist.DeclansareEveniment(x);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
        static void ManipulareEv(int n)
        {
            Console.WriteLine("Evenimentul s-a petrecut!");
        }
    }
    class Distribuitor
    {
        public event Iterare Eveniment;
        public void DeclansareEveniment(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (Eveniment != null)
                {
                    Eveniment(n);
                }
            }
        }
    }
    class AbonamentA
    {
        public void AAbonManipulare(int n)
        {
            Console.WriteLine("A a primit notificare pentru eveniment");
        }
    }
    class AbonamentB
    {
        public void BAbonManipulare(int n)
        {
            Console.WriteLine("B a primit notificare pentru eveniment");
        }
    }
}
