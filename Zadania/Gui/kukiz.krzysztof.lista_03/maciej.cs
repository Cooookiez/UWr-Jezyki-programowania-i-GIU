using System;
 
namespace lista3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tworca tworca = new Tworca();
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(string.Format("------ Krok {0} ------", i));
                tworca.newObserwator();
            }
        }
        public class Tworca
        {
            private static int count = 0;
            static Random rand = new Random();
 
            public delegate void OnNewObservatorHandler(Tworca tworca, Obserwator NowyObserwator);
            public OnNewObservatorHandler nowy;
 
            public delegate void OnWypiszHandler();
            public OnWypiszHandler wypisz;
 
            public void newObserwator()
            {
                Obserwator obserwator = new Obserwator(count, Math.Round(rand.NextDouble(), 3), Math.Round(rand.NextDouble(), 3));
                count++;
                if (nowy != null) { nowy(this, obserwator); }
 
                obserwator.Subscribe(this); //od razu subskrybuje po utworzeniu
                
                if (wypisz != null) { wypisz(); }
            }
        }
 
        public class Obserwator {
            int nazwa;
            double x;
            double y;
 
            Obserwator[] sasiedzi = new Obserwator[2]; // 0- najblizszy sasiad, 1 - kolejny sasiad
            double[] odl = new double[2];
 
            public Obserwator(int nazwa, double x, double y)
            {
                this.nazwa = nazwa;
                this.x = x;
                this.y = y;
            }
 
            public void Subscribe(Tworca tworca) {
                tworca.nowy += nowyObserwator;
                tworca.wypisz += wypisz;
            }
 
            public void nowyObserwator(Tworca tworca, Obserwator nowyObserwator)
            {
                double odl = Math.Round(Math.Sqrt(Math.Pow((this.x - nowyObserwator.x),2) + Math.Pow((this.y - nowyObserwator.y) ,2)) ,3);
                if (this.sasiedzi[0] == null)
                {
                    this.sasiedzi[0] = nowyObserwator; this.odl[0] = odl;
                } else if (this.sasiedzi[1] == null)
                {
                    this.sasiedzi[1] = nowyObserwator; this.odl[1] = odl;
                }
                else if (odl.CompareTo(this.odl[1]) == -1) {
                    if (odl.CompareTo(this.odl[0]) == -1) {
                        this.sasiedzi[1] = this.sasiedzi[0]; 
                        this.odl[1] = this.odl[0];
 
                        this.sasiedzi[0] = nowyObserwator; 
                        this.odl[0] = odl;
                    } else {
                        this.sasiedzi[1] = nowyObserwator;
                        this.odl[1] = odl;
                    }
                }
            }
 
            public void wypisz()
            {
                string opis = "";
                opis += string.Format("Jestem Obs {0}, x={1}, y={2} \n", nazwa, x, y);
                int count = 0;
                foreach(Obserwator i in this.sasiedzi)
                {
                    if (i != null)
                    {
                        opis += string.Format("\tObs {0}, x={1}, y={2}, odl={3} \n", i.nazwa, i.x, i.y, this.odl[count]);
                        count++;
                    }
                } 
                Console.Write(opis);
                Console.WriteLine();
            }
        }
    }
}
 