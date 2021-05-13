using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaNume
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
            Console.WriteLine("Acest program face o lista cu nume");
            List<string> valori = new List<string>();
            valori.Add("Lionel Messi");
            valori.Add("Cristiano Ronaldo");
            valori.Add("Joe Biden");
            valori.Add("Donald Trump");
            valori.Add("Klaus Iohannis");
            ListaNume nume = new ListaNume(valori);
            string n1 = nume[0];
            Console.WriteLine(n1);
            string n2 = nume[1];
            Console.WriteLine(n2);
            string n3 = nume[2];
            Console.WriteLine(n3);
            string n4 = nume[3];
            Console.WriteLine(n4);
            string n5 = nume[4];
            Console.WriteLine(n5);
            Console.ReadKey();
        }
    }
    public class ListaNume
    {
        private string[] nume;
        public int dimensiune;
        public bool er;
        public ListaNume(List<string> valori)
        {
            dimensiune = valori.Count();
            nume = new string[valori.Count()];
            for (int i = 0; i < nume.Length; i++)
            {
                nume[i] = valori.ElementAt(i);
            }
        }
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < dimensiune)
                {
                    er = false;
                    return nume[index];
                }
                else
                {
                    er = true;
                    return index + ": Index out of range";
                }
            }
            set
            {
                if (index >= 0 && index < dimensiune)
                {
                    nume[index] = value;
                    er = false;
                }
                else
                {
                    er = true;
                }
            }
        }
        public string this[string index]
        {
            get
            {
                int i = 0;
                try
                {
                    i = int.Parse(index);
                }
                catch (FormatException)
                {
                    er = true;
                    return index + ": Number format exception!";
                }
                catch (ArgumentNullException)
                {
                    er = true;
                    return index + ": Argument Null Exception!";
                }
                catch (OverflowException)
                {
                    er = true;
                    return index + ": Overflow Exception!";
                }
                if (i >= 0 && i < dimensiune)
                {
                    er = false;
                    return nume[i];
                }
                else
                {
                    er = true;
                    return i + ": Index out of range";
                }
            }
        }
    }
}
