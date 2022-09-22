using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nobel
{
    class Program
    {
        static List<KiosztottDij> kiosztottDijak = new List<KiosztottDij>();
        static void Main(string[] args)
        {
            adatokBeolvasasa();
            feladat03();
            feladat04();
            feladat05();
            feladat06();
            feladat07();
            feladat08();

            Console.WriteLine("\nProgram vége");
            Console.ReadKey();
        }

        private static void feladat08()
        {
            // -- Hozzon létre szöveges állományt, amely tartalmazza az összes kiosztott Nobel-díj adataot
        }

        private static void feladat07()
        {
            // -- Melyik típusú díjból hány darabot osztotta ki a Nobel-díj történelme folyamán
            Console.WriteLine("7. feladat:");
            List<string> dijTipusok = new List<string>();            

            foreach (KiosztottDij dij in kiosztottDijak)
            {
                if (!dijTipusok.Contains(dij.Tipus))
                {
                    dijTipusok.Add(dij.Tipus);
                }
            }

            int[] hanyDijatOsztottakKi = new int[dijTipusok.Count];
            for (int i = 0; i < dijTipusok.Count; i++)
            {
                for (int j = 0; j < kiosztottDijak.Count; j++)
                {
                    if (kiosztottDijak[j].Tipus == dijTipusok[i])
                    {
                        hanyDijatOsztottakKi[i] += 1;
                    }

                }
            }


            for (int i = 0; i < dijTipusok.Count; i++)
            {
                Console.WriteLine($"\t{dijTipusok[i]}: {hanyDijatOsztottakKi[i]} db");
            } 

        }

        private static void feladat06()
        {
            // -- Írja ki, hogy milyen évben, a Curie család melyik tagja, milyen díjat kapott
            Console.WriteLine("6. feladat:");            
            List<KiosztottDij> talalatiLista = kiosztottDijak.FindAll(a => a.Vezeteknev.Contains("Curie"));
            foreach (KiosztottDij t in talalatiLista)
            {
                Console.WriteLine($"\t{t.Ev}: {t.Keresztnev} {t.Vezeteknev} ({t.Tipus})");
            }
        }

        private static void feladat05()
        {
            // -- Mely szervezetek kaptak béke Nobel-díjat 1990-től napjainkig
            Console.WriteLine("5. feladat:");

            List<KiosztottDij> talalatiLista = kiosztottDijak.FindAll(a => a.Ev >= 1990 && a.Ev <= DateTime.Now.Year && a.Tipus.Equals("béke") && String.IsNullOrEmpty(a.Vezeteknev) );
            
            foreach (KiosztottDij item in talalatiLista)
            {
                Console.WriteLine($"\t{item.Ev}: {item.Keresztnev}");
            }
        }

        private static void feladat04()
        {
            // -- Ki kapott 2017-ben irodalmi Nobel-díjat
            KiosztottDij keresettDij = kiosztottDijak.Find(a => a.Ev == 2017 && a.Tipus.Equals("irodalmi"));
            Console.WriteLine($"4. feladat: {keresettDij.Keresztnev} {keresettDij.Vezeteknev}");
        }

        private static void feladat03()
        {
            // -- Kiírja Arthur B. milyen típusú díjat kapott
            KiosztottDij keresettDij = kiosztottDijak.Find(a => a.Keresztnev.Equals("Arthur B."));
            Console.WriteLine($"3. feladat: {keresettDij.Tipus}");
        }

        static void adatokBeolvasasa()
        {
            using (StreamReader sr = new StreamReader("nobel.csv")) //-- leköti az erőforrást
            {
                sr.ReadLine(); //ezzel beolvassa az első sort
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    KiosztottDij kiosztottDij = new KiosztottDij(int.Parse(sor[0]), sor[1], sor[2], sor[3]);
                    kiosztottDijak.Add(kiosztottDij);
                }

            } // -- elengedi az erőforrást (sr.Close())
        }

    }
}
