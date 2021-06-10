using System;

namespace zad_01
{
    class Program
    {
        static void Main(string[] args)
        {

            // get user number
            Console.Write("Wpisz liczbe do tabliczki mnozenia: ");
            string sx = Console.ReadLine();
            int ix = 0;
            bool findingNum = true;
            do
            {
                try
                {
                    ix = Convert.ToInt32(sx);
                    // corect noumber
                    findingNum = false;
                }
                catch
                {
                    Console.Write("Wpisz LICZBE naturalną do tabliczki mnozenia: ");
                    sx = Console.ReadLine();
                }
            } while (findingNum);

            // write table
            int cellLength = Convert.ToString((ix*ix)).Length;
            string tmp;
            for (int i = 1; i <= ix; i++)
            {
                for (int j = 1; j <= ix; j++)
                {
                    tmp = Convert.ToString(i * j);
                    tmp = String.Format("{0," + cellLength + "}", tmp);
                    if (j == 1)
                    {
                        //tmp = String.Format("{0," + (cellLength + 1) + "}", tmp);
                        tmp = String.Format("{0,-" + (tmp.Length + 2) + "}", tmp);
                    } 
                    else
                    {
                        tmp += " ";
                    }
                    Console.Write(tmp + "  ");
                }
                Console.WriteLine();
                if (i == 1) Console.WriteLine(); ;
            }
        }
    }
}
