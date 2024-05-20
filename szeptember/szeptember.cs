using System;
using System.IO;
using System.Linq;


namespace hiany
{

    class Program
    {
        struct Mulaszt
        {
            public string nev;
            public string osztaly;
            public int enap;
            public int unap;
            public int ora;
        }
        static Mulaszt[] m = new Mulaszt[1000];
        static void Main(string[] args)
        {

            string[] sor = File.ReadAllLines("szeptember.csv");
            int db = 0;

            for (int i = 0; i < sor.Count(); i++)
            {

                string[] szo = sor[i].Split(';');
                m[db].nev = szo[0];
                m[db].osztaly = szo[1];
                m[db].enap = Convert.ToInt32(szo[2]);
                m[db].unap = Convert.ToInt32(szo[3]);
                m[db].ora = Convert.ToInt32(szo[4]);
                db++;
            }

            // mulasztott órák száma
            int osszes = 0;
            for (int i = 0; i < m.Length; i++)
            { osszes += m[i].ora; }
            Console.WriteLine("2. feladat");
            Console.Write("\t Mulasztott órák száma: {0}\n", osszes);
            
            // adatok bekérése
            string b;
            int a;
            Console.WriteLine("3. feladat");
            Console.Write("\t Kérem, adjon meg egy napot:");
            a = Int32.Parse(Console.ReadLine());
            Console.Write("\t Tanulo neve: ");
            b = Console.ReadLine();
            // hiányzott vagy sem
            int j = 0;
            while (b != m[j].nev)
            {
                
                j++;
            }
           
                if (m[j].ora != 0)
                    Console.WriteLine("\t A tanuló hiányzott szeptember-ben");
                else Console.WriteLine("\t A tanuló nem hiányzott szeptemberben");
            // hiányzók
            
            Console.WriteLine("5. feladat: Hiányzó tanulók 2017. szeptember {0}-én", a);
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i].enap == a)
                {
                    Console.WriteLine("\t {0} ({1})", m[i].nev, m[i].osztaly);
                }
            }

            string fnev = "osszesites.csv";
            StreamWriter f = File.CreateText(fnev);
            string[] oszt = { "1a", "1b", "2a", "2b", "3a", "3b", "4a", "4b", "5a", "5b", "6a", "6b", "7a", "7b", "8a", "8b" };
            foreach (string l in oszt)
            {
                int szam = 0;
                for (int i = 0; i < m.Length; i++)
                    if (Equals(l, m[i].osztaly))
                        szam += m[i].ora;
                string s = l + ";" + szam.ToString();
                f.WriteLine(s);
            }
            f.Close();


            Console.ReadKey();
        }
    }
}
