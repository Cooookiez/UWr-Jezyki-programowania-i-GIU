using System;

namespace zad_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyInt myInt = new MyInt(5);
            myInt.WypiszStan();
            Console.WriteLine();

            Console.WriteLine(myInt);
            myInt.WypiszStan();
            Console.WriteLine();

            myInt.val = 15;
            myInt.WypiszStan();
            Console.WriteLine();

            int xd = myInt.val;
            myInt.WypiszStan();
            Console.WriteLine();

            Console.WriteLine(myInt);
            myInt.WypiszStan();
            Console.WriteLine();

            myInt.val = 19;
            myInt.WypiszStan();
            Console.WriteLine();

            Console.WriteLine(myInt);
            myInt.WypiszStan();
            Console.WriteLine();

            myInt.val = 25;
            myInt.WypiszStan();
            Console.WriteLine();

            int dx = myInt.val;
            myInt.WypiszStan();
            Console.WriteLine();

            myInt.Ureguluj();
            myInt.WypiszStan();
            Console.WriteLine();

            myInt.val = 29;
            myInt.WypiszStan();
            Console.WriteLine();
        }
    }

    class MyInt
    {
        private int freeOperations = 0;
        private int countGets = 0;
        private int countSets = 0;
        private int myValue = 0;
        public MyInt(int freeOperations)
        {
            this.freeOperations = freeOperations;
        }

        public int val
        {
            set
            {
                if (countGets + countSets < freeOperations)
                {
                    countSets++;
                    this.myValue = value;
                }
                else
                {
                    Console.WriteLine("Nieautoryzowana próba dostępu (set val)");
                }
            }
            get 
            {
                if (countGets + countSets < freeOperations)
                {
                    countGets++;
                    return this.myValue;
                }
                Console.WriteLine("Nieautoryzowana próba dostępu (get val)");
                return -1;
            }
        }
        public override string ToString()
        {
            if (countGets + countSets < freeOperations)
            {
                countGets++;
                return this.myValue.ToString();
            }
            Console.WriteLine("Nieautoryzowana próba dostępu (ToString)");
            return (-1).ToString();
        }
        public void Ureguluj()
        {
            this.countGets = 0;
            this.countSets = 0;
        }
        public void WypiszStan()
        {
            Console.WriteLine("Liczba operacji pobrania wartości: " + this.countGets);
            Console.WriteLine("Liczba operacji nadania wartości: " + this.countSets);
        }
    }

}
