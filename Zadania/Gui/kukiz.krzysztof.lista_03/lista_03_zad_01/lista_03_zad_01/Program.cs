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

            Jahwe.CreateNew("Ania");
            Jahwe.CreateNew("Bartek");
            Jahwe.CreateNew("Celvin");
            Jahwe.CreateNew("Dawid");
            Jahwe.CreateNew("Emilia");
            Jahwe.CreateNew("Falafel");
            Jahwe.CreateNew("Gienek");
            Jahwe.CreateNew("Hubert");
            Jahwe.CreateNew("Iwona");
            Jahwe.CreateNew("Janusz");
            Jahwe.CreateNew("Kukiz");
            Jahwe.CreateNew("Lenin");
            Jahwe.CreateNew("Łukasz");
            Jahwe.CreateNew("Maciej");
            Jahwe.CreateNew("Natalia");
            Jahwe.CreateNew("Ola");
            Jahwe.CreateNew("Paweł");
            Jahwe.CreateNew("Reksio");
            Jahwe.CreateNew("Sasin");
            Jahwe.CreateNew("Tomasz");

            Console.Read();
        }
    }

    class Tworca
    {
        List<Obserwator> Obserwatorzy = new List<Obserwator>();
        Obserwator ObserwatorzyTmp;
        Random rnd = new Random();
        int krok = 0;

        public delegate void onNowySiasiad(Obserwator obserwator);
        public onNowySiasiad nowySiasiad;

        public delegate void onWypisz();
        public onWypisz wypisz;

        public void CreateNew(string name = "NoName")
        {
            Console.WriteLine($"--------------------krok {krok++}-------------------");
            ObserwatorzyTmp = new Obserwator(name, Math.Round((double)rnd.Next() / Int32.MaxValue, 3), Math.Round((double)rnd.Next() / Int32.MaxValue, 3));
            // ObserwatorzyTmp = new Obserwator(name); // mi i w tym i w tym wyżej przypadku x'sy i y'greki są różne
            ObserwatorzyTmp.Subscribe(this);
            for (int i = 0; i < Obserwatorzy.Count; i++)
            {
                if (nowySiasiad != null) nowySiasiad(Obserwatorzy[i]);
            }
            if (wypisz != null) wypisz();
            Obserwatorzy.Add(ObserwatorzyTmp);
        }
    }

    class Obserwator
    {
        double x, y;
        string name;
        Random rnd = new Random();
        List<Sasiedzi> moiSasiedzi = new List<Sasiedzi>(); // normalnie bym usuwał wszystko poza pierwszymi dwoma dla oszczędności pamięci. Dla celów debugowania / sprawdzania przez pana, nie implementuje tego

        public Obserwator(string name)
        {
            this.x = (double)rnd.Next() / Int32.MaxValue;
            this.y = (double)rnd.Next() / Int32.MaxValue;
            // zaokraglij
            this.x = Math.Round(this.x, 3);
            this.y = Math.Round(this.y, 3);
            this.name = name;
        }

        public Obserwator(string name, double x, double y)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public void Subscribe(Tworca Jahwe)
        {
            Jahwe.nowySiasiad = AddSasiad;
            Jahwe.wypisz = Wypisz;
        }

        public void AddSasiad(Obserwator obserwator)
        {
            Sasiedzi newSasiad = new Sasiedzi(this.X, this.Y, obserwator.X, obserwator.Y, obserwator.Name);
            moiSasiedzi.Add(newSasiad);
            moiSasiedzi.Sort();
        }

        public void Wypisz()
        {
            Console.WriteLine($"Jestem {this.name} - Lista sąsiadów:");
            //Console.WriteLine($"({this.X} , {this.Y}) Jestem {this.name} - Lista sąsiadów:");
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
            return this.odl > other.odl ? 1 : -1;
        }

        public override string ToString()
        {
            return $"\t{this.name}\t\tx={this.x}\t\ty={this.y}\t\todl={this.odl}";
        }
    }
}
