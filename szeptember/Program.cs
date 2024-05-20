using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hiányzzások
{
    class Program
    {
        struct sajat
        {
            public string nev;
            public string osztaly;
            public int elsonap;
            public int utolsonap;
            public int orak;
        }
        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("szeptember.csv");
            sajat[] adatok = new sajat[fajl.Length - 1];
            for (int i = 1; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i - 1].nev = darabol[0];
                adatok[i - 1].osztaly = darabol[1];
                adatok[i - 1].elsonap = Convert.ToInt32(darabol[2]);
                adatok[i - 1].utolsonap = Convert.ToInt32(darabol[3]);
                adatok[i - 1].orak = Convert.ToInt32(darabol[4]);
            }
            int sum = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                sum += adatok[i].orak;
            }
            Console.WriteLine("\n2.Feladat:");
            
            Console.WriteLine("Az összes mulasztott órák száma:{0}",sum);
        
            Console.WriteLine("\n3.Feladat:");
            
            Console.WriteLine("Kérem adjon meg egy napot!");
            int nap = Convert.ToInt32(Console.ReadLine());
         
            Console.WriteLine("Tanuló neve");
            string nev = Console.ReadLine();
            Console.WriteLine("\n4.Feladat:");
            bool van = false;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (nev==adatok[i].nev)
                {
                    van = true;
                }
            }
            if (van)
            {
                Console.WriteLine("Hiányzott");
            }
            else
            {
                Console.WriteLine("Nem hiányzott");
            }
            Console.WriteLine("\n5.Feladat: Hiányzók 2017.09.{0}-n",nap);
            for (int i = 0; i < adatok.Length; i++)
            {
                if (nap>=adatok[i].elsonap && nap<=adatok[i].utolsonap)
                {
                    Console.WriteLine("{0} ({1})",adatok[i].nev,adatok[i].osztaly);
                }
                else
                {
                    Console.WriteLine("Nem volt hiányzó");
                }
            }
            
            
            Console.WriteLine("\n6.Feladat:");
            int[] sumossz = new int[16];
           for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].osztaly=="1a")
                {
                    sumossz[0]+=adatok[i].orak;
                }
                if (adatok[i].osztaly == "2a")
                {
                    sumossz[1] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "3a")
                {
                    sumossz[2] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "4a")
                {
                    sumossz[3] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "5a")
                {
                    sumossz[4] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "6a")
                {
                    sumossz[5] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "7a")
                {
                    sumossz[6] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "8a")
                {
                    sumossz[7] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "1b")
                {
                    sumossz[8] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "2b")
                {
                    sumossz[9] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "3b")
                {
                    sumossz[10] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "4b")
                {
                    sumossz[11] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "5b")
                {
                    sumossz[12] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "6b")
                {
                    sumossz[13] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "7b")
                {
                    sumossz[14] += adatok[i].orak;
                }
                if (adatok[i].osztaly == "8b")
                {
                    sumossz[15] += adatok[i].orak;
                }
                     
            }

            string[] fajlba = new string[16];
            fajlba[0] = "1a;" + Convert.ToString(sumossz[0]);
            fajlba[1] = "2a;" + Convert.ToString(sumossz[1]);
            fajlba[2] = "3a;" + Convert.ToString(sumossz[2]);
            fajlba[3] = "4a;" + Convert.ToString(sumossz[3]);
            fajlba[4] = "5a;" + Convert.ToString(sumossz[4]);
            fajlba[5] = "6a;" + Convert.ToString(sumossz[5]);
            fajlba[6] = "7a;" + Convert.ToString(sumossz[6]);
            fajlba[7] = "8a;" + Convert.ToString(sumossz[7]);
            fajlba[8] = "1b;" + Convert.ToString(sumossz[8]);
            fajlba[9] = "2b;" + Convert.ToString(sumossz[9]);
            fajlba[10] = "3b;" + Convert.ToString(sumossz[10]);
            fajlba[11] = "4b;" + Convert.ToString(sumossz[11]);
            fajlba[12] = "5b;" + Convert.ToString(sumossz[12]);
            fajlba[13] = "6b;" + Convert.ToString(sumossz[13]);
            fajlba[14] = "7b;" + Convert.ToString(sumossz[14]);
            fajlba[15] = "8b;" + Convert.ToString(sumossz[15]);

             File.WriteAllLines("osszesites.csv", fajlba);
            
            Console.ReadKey();
		 

        }
    }
}
