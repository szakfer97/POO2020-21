using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrganizareStiva
{
    class Program 
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Numele meu este Szakacsi Ferenc-Adam");
                Console.WriteLine("Acest program lucreaza cu stiva");
                Console.WriteLine("Stiva cu valori int:");
                Stiva<int> stint = new Stiva<int>(4);
                stint.Push(1);
                stint.Push(2);
                stint.Push(3);
                stint.Push(4);
                Console.WriteLine(stint.Pop());
                Console.WriteLine(stint.Pop());
                Console.WriteLine(stint.Pop());
                Console.WriteLine(stint.Pop());
                Console.WriteLine("Stiva cu valori string:");
                Stiva<string> ststr = new Stiva<string>(4);
                ststr.Push("1");
                ststr.Push("2");
                ststr.Push("3");
                ststr.Push("4");
                Console.WriteLine(ststr.Pop());
                Console.WriteLine(ststr.Pop());
                Console.WriteLine(ststr.Pop());
                Console.WriteLine(ststr.Pop());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($" {e.Message}");
            }
        }
    }
    public class Stiva<T>
    {
        private T[] data;
        private int num;
        public Stiva(int n)
        {
            data = new T[n];
            num = 0;
        }
        public bool Empty
        {
            get
            {
                return num == 0;
            }
        }
        public void Push(T v)
        {
            if (num < data.Length)
            {
                data[num++] = v;
            }
            else
            {
                throw new StackFullException("Stiva este plina");
            }   
        }
        public T Pop()
        {
            if (!this.Empty)
            {
                num--;
                return data[num];
            }
            else
            {
                throw new StackEmptyException("Stiva este goala");
            }   
        }
        public T Peek()
        {
            if (!this.Empty)
            {
                return data[num - 1];
            }
            else
            {
                throw new StackEmptyException("Stiva este goala");
            }
        }
        public void Clear()
        {
            data = new T[data.Length];
            num = 0;
        }
    }
    [Serializable]
    internal class StackFullException : Exception
    {
        public StackFullException()
        {
        }
        public StackFullException(string message) : base(message)
        {
        }
        public StackFullException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected StackFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    internal class StackEmptyException : Exception
    {
        public StackEmptyException()
        {
        }
        public StackEmptyException(string message) : base(message)
        {
        }
        public StackEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected StackEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
