using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Elev
{
    class Program
    {
        public static List<Elevi> elevi = new List<Elevi>();
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program sorteaza notele elevilor");
                Console.WriteLine("--------------------Elevii si notele lor--------------------");
                Intrare();
                Console.WriteLine("--------------------Elevii si media lor---------------------");
                Sortare();
                Iesire();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
        public static void Intrare()
        {
            string cale = @"../../Lista.in";
            TextReader incarc = new StreamReader(cale);
            string buffer;
            while ((buffer = incarc.ReadLine()) != null)
            {
                Console.WriteLine(buffer);
                string[] local = buffer.Split(' ');
                string nume = local[0];
                string prenume = local[1];
                List<int> note = new List<int>();
                for (int i = 2; i < local.Length; i++)
                {
                    if (int.TryParse(local[i], out int nota))
                    {
                        note.Add(nota);
                    }
                }
                elevi.Add(new Elevi(nume, prenume, note));
            }
        }
        public static void Sortare()
        {
            elevi.Sort();
            elevi.Reverse();
            foreach (Elevi elev in elevi)
            {
                Console.WriteLine(elev);
            }
        }
        public static void Iesire()
        {
            string cale = @"../../Lista.out";
            List<string> iesire = new List<string>();
            foreach (Elevi elev in elevi)
            {
                iesire.Add(elev.ToString());
            }
            File.WriteAllLines(cale, iesire);
        }
    }
    public class Elevi : IComparable<Elevi>
    {
        public string nume;
        public string prenume;
        public double media;

        public string Nume
        {
            get
            {
                return nume;
            }
        }
        public string Prenume
        {
            get
            {
                return prenume;
            }
        }
        public double Media
        {
            get
            {
                return media;
            }
        }
        public Elevi(string nume, string prenume, List<int> note)
        {
            this.nume = nume;
            this.prenume = prenume;
            double media = 0;
            for (int i = 0; i < note.Count; i++)
            {
                media += note[i];
            }
            this.media = media / note.Count;
        }
        public override string ToString()
        {
            return $"{Nume} {Prenume} {Media}";
        }
        public int CompareTo(Elevi alt)
        {
            int numedif = 2;
            int rezultat = Media.CompareTo(alt.Media);
            if (rezultat == 0)
            {
                numedif = Nume.CompareTo(alt.Nume);
            }
            if (numedif == 0)
            {
                numedif = Prenume.CompareTo(alt.Prenume);
            }
            if (numedif != 2)
            {
                return -numedif;
            }
            return rezultat;
        }
    }
}
