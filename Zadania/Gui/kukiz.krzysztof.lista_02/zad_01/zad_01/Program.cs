using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace zad_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lista 1");
            //{} < {1} < {1,4,1,5,8,5,9} < {2} < {2,1} < {2,4,10,3} < {2,5,8} <{2,6}
            List<Lista1> listy1 = new List<Lista1>();
            listy1.Add(new Lista1(new List<int> { }));
            listy1.Add(new Lista1(new List<int> { 1 }));
            listy1.Add(new Lista1(new List<int> { 2 }));
            listy1.Add(new Lista1(new List<int> { 2, 1 }));
            listy1.Add(new Lista1(new List<int> { 2, 6 }));
            listy1.Add(new Lista1(new List<int> { 2, 5, 8 }));
            listy1.Add(new Lista1(new List<int> { 2, 4, 10, 3 }));
            listy1.Add(new Lista1(new List<int> { 1, 4, 1, 5, 8, 5, 9 }));
            for (int i = 0; i < listy1.Count; i++) Console.WriteLine(listy1[i]);
            listy1.Sort();
            Console.WriteLine("\\/ \\/ \\/");
            for (int i = 0; i < listy1.Count; i++) Console.WriteLine(listy1[i]);
            Console.WriteLine();

            Console.WriteLine("Lista 2");
            //{} < {1} < {2} < {2,1} < {2,6} < {2,5,8} < {2,4,10,3} < {1,4,1,5,8,5,9}
            List<Lista2> listy2 = new List<Lista2>();
            listy2.Add(new Lista2(new List<int> { }));
            listy2.Add(new Lista2(new List<int> { 1 }));
            listy2.Add(new Lista2(new List<int> { 1, 4, 1, 5, 8, 5, 9 }));
            listy2.Add(new Lista2(new List<int> { 2 }));
            listy2.Add(new Lista2(new List<int> { 2, 1 }));
            listy2.Add(new Lista2(new List<int> { 2, 4, 10, 3 }));
            listy2.Add(new Lista2(new List<int> { 2, 5, 8 }));
            listy2.Add(new Lista2(new List<int> { 2, 6 }));
            for (int i = 0; i < listy2.Count; i++) Console.WriteLine(listy2[i]);
            listy2.Sort();
            Console.WriteLine("\\/ \\/ \\/");
            for (int i = 0; i < listy2.Count; i++) Console.WriteLine(listy2[i]);
            Console.WriteLine();
        }
    }

    class Lista
    {
        protected List<int> lista = new List<int>();
        Random rnd = new Random();
        public Lista()
        {
            int listSize = rnd.Next() % 5 + 1;
            this.lista.Clear();
            for (uint i = 0; i < listSize; i++)
            {
                this.lista.Add(rnd.Next() % 100 + 1);
            }
        }
        public Lista(int n)
        {
            this.lista.Clear();
            for (uint i = 0; i < n; i++)
            {
                this.lista.Add(rnd.Next() % 100 + 1);
            }
        }
        public Lista(List<int> l)
        {
            this.lista.Clear();
            this.lista = l;
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

    class Lista1 : Lista, IComparable<Lista1>
    {
        public Lista1(List<int> l) : base(l) { }
        public int CompareTo(Lista1 other)
        {
            int n = this.lista.Count > other.lista.Count ? this.lista.Count : other.lista.Count;
            for (int i = 0; i < n; i++)
            {
                if (this.lista.Count < i + 1)
                {
                    return -1;
                }
                else if (other.lista.Count < i + 1)
                {
                    return 1;
                }
                else
                {
                    if (this.lista[i] > other.lista[i])
                    {
                        return 1;
                    }
                    else if (this.lista[i] < other.lista[i])
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }


    class Lista2 : Lista, IComparable<Lista2>
    {
        public Lista2(List<int> l) : base(l) { }
        public int CompareTo([AllowNull] Lista2 other)
        {
            if (this.lista.Count > other.lista.Count)
            {
                return 1;
            }
            else if (this.lista.Count < other.lista.Count)
            {
                return -1;
            }
            else
            {
                if (this.lista == other.lista)
                {
                    return 0;
                }
                else
                {
                    for (int i = 0; i < this.lista.Count; i++)
                    {
                        if (this.lista[i] > other.lista[i]) return 1;
                        if (this.lista[i] < other.lista[i]) return -1;
                    }
                }
            }
            return 0;
        }

    }
}
