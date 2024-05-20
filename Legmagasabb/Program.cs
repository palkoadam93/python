using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace legmagasabb
{
    class Program
    {
        struct sajat
        {
            public string nev;
            public string varos;
            public string orszag;
            public double magassag; 
            public int emelet;
            public int epult;
        }
      
        struct orszagadat
        {
            public string orszag;
            public int db;
        }

        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("legmagasabb.txt");
            sajat[] adatok = new sajat[fajl.Length - 1];
            
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] darabol = fajl[i + 1].Split(';');
                adatok[i].nev = darabol[0];
                adatok[i].varos = darabol[1];
                adatok[i].orszag = darabol[2];
                adatok[i].magassag=Convert.ToDouble(darabol[3]);
                adatok[i].emelet= Convert.ToInt32(darabol[4]);
                adatok[i].epult = Convert.ToInt32(darabol[5]);
            }
            Console.WriteLine("3.Feladat: Épületek száma: {0} db",adatok.Length);
            Console.WriteLine();
            int szum = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                szum += adatok[i].emelet;
            }
            Console.WriteLine("4.Feladat:Emeletek összege:{0}",szum);
            Console.WriteLine();
              double max = adatok[0].magassag;
              int index = 0;
              for (int i = 1; i < adatok.Length; i++)
              {
                  if (max<adatok[i].magassag)
                  {
                      max = adatok[i].magassag;
                      index = i;
                  }
              }
              Console.WriteLine("5.Feladat: A legmagasabb épület adatai:");
              Console.WriteLine();
              Console.WriteLine("Név:{0}",adatok[index].nev);
              Console.WriteLine("Város:{0}", adatok[index].varos);
              Console.WriteLine("Ország:{0}", adatok[index].orszag);
              Console.WriteLine("Magasság:{0:00.0}", adatok[index].magassag);
              Console.WriteLine("Emelet:{0}", adatok[index].emelet);
              Console.WriteLine("Épült:{0}", adatok[index].epult);
              Console.WriteLine();
              Console.WriteLine("6.Feladat:");
              Console.WriteLine();
              bool van = false;
              int k = 0;
              do
              {
                  if (adatok[k].orszag=="olasz")
                  {
                      van = true;
                  }                 
                  k++;
              } while (van==false||k<adatok.Length);
              if (van)
              {
                  Console.WriteLine("Van benne olasz.");
              }
              else
              {
                  Console.WriteLine("Nincs benne olasz.");
              }
              Console.WriteLine();
             int db = 0;
             for (int i = 0; i < adatok.Length; i++)
             {
                 if (adatok[i].magassag*3.28>666)
                 {
                     db++;
                 }
             } 
            Console.WriteLine("7.Feladat: A 666 lábnál magasabb épületek száma:{0}", db);
             Console.WriteLine();
            
            Console.WriteLine("8.Feladat: Ország statisztika");
             Console.WriteLine();

            orszagadat[] stat = new orszagadat[15];
            stat[0].orszag=("Anglia");
            stat[1].orszag=("Oroszország");
            stat[2].orszag=("Bosznia-Hercegovina");
            stat[3].orszag=("Lengyelország");
            stat[4].orszag=("Németország");
            stat[5].orszag=("Franciaország");
            stat[6].orszag=("Ausztria");
            stat[7].orszag=("Belgium");
            stat[8].orszag=("Litvánia");
            stat[9].orszag=("Olaszország");
            stat[10].orszag=("Hollandia");
            stat[11].orszag=("Spanyolország");
            stat[12].orszag=("Törökország");
            stat[13].orszag=("Svédország");
            stat[14].orszag=("Szerbia");

            for (int i = 0; i < adatok.Length; i++)
            {
                for (int j = 0; j < stat.Length; j++)
                {
                    if (adatok[i].orszag==stat[j].orszag)
                    {
                        stat[j].db++;
                    }
                }
            } 
            for (int i = 0; i < stat.Length; i++)
            {
                Console.WriteLine(" {0} - {1} db",stat[i].orszag, stat[i].db);
            }
            Console.WriteLine();
            Console.WriteLine("9.Feladat:");
            
            List<string> varos =new List<string>();
            for (int i = 0; i < adatok.Length; i++)
			{
                if (adatok[i].orszag=="Németország")
                {
                    varos.Add(adatok[i].varos); 
                }
			}
            File.WriteAllLines("nemet.txt",varos);
            Console.ReadKey();
        }
    }
}
