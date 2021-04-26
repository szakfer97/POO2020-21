using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrice
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu matrici");
                double[,] matrice1 = new double[2, 2]
                {
                 {1,2},
                 {3,4}
                };
                double[,] matrice2 = new double[2, 2]
                {
                 {5,6},
                 {7,8}
                };
                int put = int.Parse(Console.ReadLine());
                Matrice a = new Matrice(2, matrice1);
                Matrice b = new Matrice(2, matrice2);
                Matrice c = b.Adunare(a);
                Matrice d = b.Scadere(a);
                Matrice f = b.Inmultire(a);
                Matrice g = b.Putere(put);
                Matrice h = b.Inversare();
                Console.WriteLine("Adunarea rezulta:");
                Console.WriteLine(c);
                Console.WriteLine("Scaderea rezulta:");
                Console.WriteLine(d);
                Console.WriteLine("Inmultirea rezulta:");
                Console.WriteLine(f);
                Console.WriteLine("Ridicarea la putere rezulta:");
                Console.WriteLine(g);
                Console.WriteLine("Inversarea rezulta:");
                Console.WriteLine(h);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
    }
    class Matrice
    {
        public int n, m;
        public double[,] valori;
        public Matrice(int n)
        {
            this.m = n;
            this.n = n;
            valori = new double[m, n];
        }
        public Matrice(int m, int n)
        {
            this.m = m;
            this.n = n;
            valori = new double[m, n];
        }
        public Matrice(int n, double[,] valori)
        {
            this.m = n;
            this.n = n;
            this.valori = valori;
        }
        public Matrice(int m, int n, double[,] valori)
        {
            this.m = m;
            this.n = n;
            this.valori = valori;
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str += valori[i, j] + " ";
                }
                str += '\n';
            }
            return str;
        }
        public Matrice Adunare(Matrice a)
        {
            if (a.m == this.m && a.n == this.n)
            {
                Matrice rezultat = new Matrice(m, n);
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        rezultat.valori[i, j] = this.valori[i, j] + a.valori[i, j];
                    }
                }
                return rezultat;
            }
            Console.WriteLine("Cele doua matrici n-au dimensiuni egale");
            return null;
        }
        public Matrice Scadere(Matrice a)
        {
            if (a.m == this.m && a.n == this.n)
            {
                Matrice rezultat = new Matrice(m, n);
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        rezultat.valori[i, j] = this.valori[i, j] - a.valori[i, j];
                    }
                }
                return rezultat;
            }
            Console.WriteLine("Cele doua matrici n-au dimensiuni egale");
            return null;
        }
        public Matrice Inmultire(Matrice a)
        {
            if (this.n != a.m)
            {
                Console.WriteLine("Nu este posibila inmultirea");
                return null;
            }
            else
            {
                Matrice rezultat = new Matrice(this.m, this.n);
                for (int i = 0; i < this.m; i++)
                {
                    for (int j = 0; j < a.n; j++)
                    {
                        rezultat.valori[i, j] = 0;
                        for (int k = 0; k < this.n; k++)
                        {
                            rezultat.valori[i, j] += this.valori[i, k] * a.valori[k, j];
                        }
                    }
                }
                return rezultat;
            }
        }
        public Matrice Putere(int s)
        {
            if (this.m != this.n)
            {
                Console.WriteLine("Nefiind o matrice patratica,ridicarea la putere este imposibila");
                return null;
            }
            Matrice rezultat = new Matrice(this.m, this.n, this.valori);
            for (int i = 0; i < s - 1; i++)
            {
                rezultat = rezultat.Inmultire(this);
            }
            return rezultat;
        }
        public double Determinant(double[,] a, int s)
        {
            int i, j;
            double d, e, f;
            if (s == 1)
            {
                return a[0, 0];
            }
            else
            {
                d = 0.0;
                for (j = 0; j < s; j++)
                {
                    if (((s - 1 - j) % 2 == 1) || (j == s - 1))
                        e = a[s - 1, j];
                    else
                        e = -a[s - 1, j];
                    for (i = 0; i < s - 1; i++)
                    {
                        f = a[i, j];
                        a[i, j] = a[i, s - 1];
                        a[i, s - 1] = f;
                    }
                    if ((s - 1 + j) % 2 == 0)
                        d += e * Determinant(a, s - 1);
                    else
                        d -= e * Determinant(a, s - 1);
                    for (i = 0; i < s - 1; i++)
                    {
                        f = a[i, j];
                        a[i, j] = a[i, s - 1];
                        a[i, s - 1] = f;
                    }
                }
                return d;
            }
        }
        public Matrice Inversare()
        {
            if (this.m == this.n)
            {
                double d = this.Determinant(this.valori, this.m);
                if (d != 0)
                {
                    Matrice rezultat = new Matrice(this.m);
                    Matrice temp = new Matrice(this.m);
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            temp.valori[i, j] = this.valori[j, i];
                        }
                    }
                    double f;
                    int semn;
                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < m; j++)
                        {

                            for (int k = 0; k < m; k++)
                            {
                                f = temp.valori[i, k];
                                temp.valori[i, k] = temp.valori[m - 1, k];
                                temp.valori[m - 1, k] = f;
                            }

                            for (int k = 0; k < m; k++)
                            {
                                f = temp.valori[k, j];
                                temp.valori[k, j] = temp.valori[k, m - 1];
                                temp.valori[k, m - 1] = f;
                            }
                            semn = 1;
                            if (((m - 1 - i) % 2 == 0) && (i != m - 1))
                                semn *= -1;
                            if (((m - 1 - j) % 2 == 0) && (j != m - 1))
                                semn *= -1;
                            if ((i + j) % 2 == 1)
                                semn *= -1;
                            rezultat.valori[i, j] = semn * Determinant(temp.valori, m - 1);
                            for (int k = 0; k < m; k++)
                            {
                                f = temp.valori[i, k];
                                temp.valori[i, k] = temp.valori[m - 1, k];
                                temp.valori[m - 1, k] = f;
                            }
                            for (int k = 0; k < m; k++)
                            {
                                f = temp.valori[k, j];
                                temp.valori[k, j] = temp.valori[k, m - 1];
                                temp.valori[k, m - 1] = f;
                            }
                        }
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            rezultat.valori[i, j] /= d;
                        }
                    }
                    return rezultat;
                }
                Console.WriteLine("Determinantul fiind zero face inversarea imposibila");
                return null;
            }
            Console.WriteLine("Nefiind o matrice patratica face inversarea imposibila");
            return null;
        }
    }
}
