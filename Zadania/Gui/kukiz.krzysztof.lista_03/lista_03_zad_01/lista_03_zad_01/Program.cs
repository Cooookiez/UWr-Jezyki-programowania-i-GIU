using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace lista_03_zad_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Tworca Jahwe = new Tworca();

            // krok 0
            Jahwe.CreateNew("Ania");
            Jahwe.WypiszObserwatorow(0);

            // krok 1
            Jahwe.CreateNew("Bartek");
            Jahwe.WypiszObserwatorow(1);

            // krok 2
            Jahwe.CreateNew("Celvin");
            Jahwe.WypiszObserwatorow(2);

            // krok 3
            Jahwe.CreateNew("Dawid");
            Jahwe.WypiszObserwatorow(3);

            // krok 4
            Jahwe.CreateNew("Emilia");
            Jahwe.WypiszObserwatorow(4);

            // krok 5
            Jahwe.CreateNew("Falafel");
            Jahwe.WypiszObserwatorow(5);
        }
    }

    class Tworca
    {
        List<Obserwator> Obserwatorzy = new List<Obserwator>();
        Obserwator ObserwatorzyTmp;

        public void CreateNew(string name = "NoName")
        {
            ObserwatorzyTmp = new Obserwator(name);
            Nowy(ObserwatorzyTmp);
            Obserwatorzy.Add(ObserwatorzyTmp);
        }

        void Nowy(Obserwator ObserwatorzyTmp)
        {
            Sasiedzi tmpSasiad;
            for (int i = 0; i < Obserwatorzy.Count; i++)
            {
                //Obserwatorzy[i];
                tmpSasiad = new Sasiedzi(Obserwatorzy[i].X, Obserwatorzy[i].Y, ObserwatorzyTmp.X, ObserwatorzyTmp.Y, ObserwatorzyTmp.Name);
                Obserwatorzy[i].AddSasiad(tmpSasiad);
            }
        }

        public void WypiszObserwatorow(string krok = "0")
        {
            Console.WriteLine($"--------------------krok {krok}-------------------");
            for (int i = 0; i < Obserwatorzy.Count; i++)
            {
                Obserwatorzy[i].Wypisz();
            }
            Console.WriteLine();
        }

        public void WypiszObserwatorow(int krok = 0)
        {
            this.WypiszObserwatorow(krok.ToString());
        }
    }

    class Obserwator
    {
        double x, y;
        string name;
        Random rnd = new Random();
        List<Sasiedzi> moiSasiedzi = new List<Sasiedzi>();

        public Obserwator(string name)
        {
            this.x = (double)rnd.Next() / Int32.MaxValue;
            this.y = (double)rnd.Next() / Int32.MaxValue;
            // zaokraglij
            this.x = Math.Round(this.x, 3);
            this.y = Math.Round(this.y, 3);
            this.name = name;
        }

        public void AddSasiad(Sasiedzi newSasiad)
        {
            moiSasiedzi.Add(newSasiad);
            this.moiSasiedzi.Sort();
        }

        public void Wypisz()
        {
            Console.WriteLine($"Jestem {this.name} - Lista sąsiadów:");
            for (int i = 0; i < this.moiSasiedzi.Count; i++)
            {
                Console.WriteLine(this.moiSasiedzi[i]);
                if (i >= 1) break;
            }
        }

        public double X
        {
            get
            {
                return this.x;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }

    class Sasiedzi : IComparable<Sasiedzi>
    {
        double x, y, odl;
        string name;

        public Sasiedzi(double myX, double myY, double sonsiadX, double sonsiadY, string name)
        {
            this.x = sonsiadX;
            this.y = sonsiadY;
            this.name = name;
            this.odl = Math.Sqrt(Math.Pow(sonsiadX - myX, 2) + Math.Pow(sonsiadY - sonsiadX, 2));
            this.odl = Math.Round(this.odl, 3);
        }

        public int CompareTo([AllowNull] Sasiedzi other)
        {
            return this.odl > other.odl ? 1 : 0;
        }

        public override string ToString()
        {
            return $"\t{this.name}\t\tx={this.x}\t\ty={this.y}\t\todl={this.odl}";
        }
    }
}
