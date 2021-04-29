using System;
using System.Collections.Generic;

namespace zad_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Lista lista = new Lista(10);
            Lista1 lista1 = new Lista1();
            Console.WriteLine(lista);
            Console.WriteLine(lista1);
        }
    }

    class Lista
    {
        protected List<int> lista = new List<int>();
        public Lista(int n)
        {
            Random rnd = new Random();
            this.lista.Clear();
            for (uint i = 0; i < n; i++)
            {
                this.lista.Add(rnd.Next() % 100 + 1);
            }
        }
        public Lista()
        {
            Random rnd = new Random();
            int listSize = rnd.Next() % 5 + 1;
            this.lista.Clear();
            for (uint i = 0; i < listSize; i++)
            {
                this.lista.Add(rnd.Next() % 100 + 1);
            }
        }
        public override string ToString()
        {
            string newStr = "";
            int n = this.lista.Count;
            newStr += "{";
            for (int i = 0; i < n; i++)
            {
                newStr += this.lista[i];
                if (i < n - 1)
                {
                    newStr += ",";
                }
            }
            newStr += "}";
            return newStr;
        }
    }

    class Lista1 : Lista
    {
        Lista lista = new Lista();
    }
}
