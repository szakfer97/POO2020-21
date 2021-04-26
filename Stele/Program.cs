using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stele
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program ilustreaza stele");
                int st = int.Parse(Console.ReadLine());
                Stele s = new Stele(st);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
    }
    public class Stele
    {
        public int stele;
        public Stele(int stele)
        {
            this.stele = stele;
            for (int i = 0; i < stele; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    Console.Write("*");
                }
                Console.WriteLine("*");
            }
            for (int i = stele; i >= 1; --i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < stele; i++)
            {
                if (i == 0 || i == 6)
                {
                    for (int j = 0; j < stele - 1; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                if (i >= 1 && i <= 5)
                {
                    for (int j = 0; j < stele - 1; j++)
                    {
                        if (j == 0 || j == 6)
                        {
                            Console.Write("*");
                        }
                        else if (j >= 1 && j <= 5)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
