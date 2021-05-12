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
            try
            {
                List<string> values = new List<string>();
                values.Add("Szakacsi Ferenc-Adam");
                values.Add("Cristiano Ronaldo");
                values.Add("Lionel Messi");
                values.Add("Donald Trump");
                values.Add("Klaus Iohannis");
                ListaNume nume = new ListaNume(values);
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
            catch(Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }           
        }
    }
    public class ListaNume
    {
        private string[] nume;
        public int dimensiune;
        public bool err;
        public ListaNume(List<string> values)
        {
            dimensiune = values.Count();
            nume = new string[values.Count()];
            for (int i = 0; i < nume.Length; i++)
            {
                nume[i] = values.ElementAt(i);
            }
        }
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < dimensiune)
                {
                    err = false;
                    return nume[index];
                }
                else
                {
                    err = true;
                    return index + ": Index out of range";
                }
            }
            set
            {
                if (index >= 0 && index < dimensiune)
                {
                    nume[index] = value;
                    err = false;
                }
                else
                    err = true;
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
                    err = true;
                    return index + ": Number format exception!";
                }
                catch (ArgumentNullException)
                {
                    err = true;
                    return index + ": Argument Null Exception!";
                }
                catch (OverflowException)
                {
                    err = true;
                    return index + ": Overflow Exception!";
                }
                if (i >= 0 && i < dimensiune)
                {
                    err = false;
                    return nume[i];
                }
                else
                {
                    err = true;
                    return i + ": Index out of range";
                }
            }
        }
    }
}
