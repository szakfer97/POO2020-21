using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarMare
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu numere mari");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());
                int d = int.Parse(Console.ReadLine());
                NumarMare m = new NumarMare(a);
                NumarMare n = new NumarMare(b);
                NumarMare o = m.Factorial(c);
                NumarMare p = m.TermenFibonacci(d);
                Console.WriteLine($"Adunarea rezulta:{m + n}");
                Console.WriteLine($"Inmultirea rezulta:{m * n}");
                Console.WriteLine($"Factorialul lui {c} este {o}");
                Console.WriteLine($"Termenul {d} al sirului lui Fibonacci este {p}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
    }
    class NumarMare
    {
        public List<int> cifre = new List<int>();
        public NumarMare(List<int> CifreNoi)
        {
            cifre.AddRange(CifreNoi);
        }
        public NumarMare(string s)
        {
            int lun = s.Length;
            for (int i = lun - 1; i >= 0; i--)
            {
                cifre.Add(s[i] - '0');
            }
        }
        public NumarMare()
        {
            return;
        }
        public NumarMare(int s)
        {
            do
            {
                cifre.Add(s % 10);
                s /= 10;
            } while (s > 0);
        }
        public override string ToString()
        {
            string s = "";
            for (int i = cifre.Count - 1; i >= 0; i--)
            {
                s += cifre[i];
            }
            return s;
        }
        public static NumarMare operator +(NumarMare a, NumarMare b)
        {
            NumarMare suma = new NumarMare();
            int idx = 0;
            while (idx < a.cifre.Count && idx < b.cifre.Count)
            {
                int CifraNoua = a.cifre[idx] + b.cifre[idx];
                suma.cifre.Add(CifraNoua);
                idx++;
            }
            while (idx < a.cifre.Count)
            {
                int CifraNoua = a.cifre[idx];
                suma.cifre.Add(CifraNoua);
                idx++;
            }
            while (idx < b.cifre.Count)
            {
                int CifraNoua = b.cifre[idx];
                suma.cifre.Add(CifraNoua);
                idx++;
            }
            idx = 0;
            while (idx < suma.cifre.Count)
            {
                int rest = suma.cifre[idx] / 10;
                suma.cifre[idx] %= 10;
                if (rest > 0)
                {
                    if (idx + 1 >= suma.cifre.Count)
                    {
                        suma.cifre.Add(0);
                    }
                    suma.cifre[idx + 1] += rest;
                }
                idx++;
            }
            return suma;
        }
        public static NumarMare operator *(NumarMare a, NumarMare b)
        {
            NumarMare produs = new NumarMare();
            for (int i = 0; i < b.cifre.Count; i++)
            {
                for (int j = 0; j < a.cifre.Count; j++)
                {
                    int ProdInt = b.cifre[i] * a.cifre[j];
                    if (i + j >= produs.cifre.Count) produs.cifre.Add(0);
                    produs.cifre[i + j] += ProdInt;
                }
            }
            int idx = 0;
            while (idx < produs.cifre.Count)
            {
                int rest = produs.cifre[idx] / 10;
                produs.cifre[idx] %= 10;
                if (idx + 1 >= produs.cifre.Count && rest > 0)
                {
                    produs.cifre.Add(0);
                }
                if (rest > 0)
                {
                    produs.cifre[idx + 1] += rest;
                }
                idx++;
            }
            return produs;
        }
        public NumarMare Factorial(int n)
        {
            NumarMare factorial = new NumarMare(1);
            for (int i = 2; i <= n; i++)
            {
                factorial *= new NumarMare(i);
            }
            return factorial;
        }
        public NumarMare TermenFibonacci(int n)
        {
            NumarMare a = new NumarMare(0);
            NumarMare b = new NumarMare(1);
            NumarMare c = new NumarMare(1);
            NumarMare d = new NumarMare();
            if (n <= 2) return c;
            for (int i = 3; i <= n; i++)
            {
                d = b + c;
                b = new NumarMare(c.cifre);
                c = new NumarMare(d.cifre);
            }
            return d;
        }
    }
}
