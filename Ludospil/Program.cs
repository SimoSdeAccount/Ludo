using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludospil
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Muligheder:

            Eventuelt skal man lave en klasse der kan oprette spillere, og så en game klasse som thomas, 
            som er klassen der sætter spillet igang. 

             */
            bool spilIgang = true;
            Terning Terning = new Terning();
            Farve Farver = new Farve();
            List<Spiller> Spillere = new List<Spiller>();
            /*Start på oprettelse af spillere-------------------------------------------------------------------------------------------*/
            //Herunder sættes spillet igang hvis man vælger at ville spille.
            while(spilIgang == true)
            {
                //Herunder vælges der om man vil spille eller ej. Hvis ikke lukkes programmet.
                Console.WriteLine("Vil du spille? Tast y for ja og n for nej");
                string svar = Console.ReadLine();
                if(svar == "y")
                {
                    //Hvis man vil spille skal man først vælge antal spillere.
                    Console.WriteLine("Vælg antal spillere, højst 4.");
                    int antalSpillere = int.Parse(Console.ReadLine());
                    if(antalSpillere <= 4)
                    {
                        int SpillerCounter = 1;
                        //Efter antal spillere er valgt oprettes spillere og konfigureres med farve
                        while(SpillerCounter <= antalSpillere)
                        {
                            Console.WriteLine("Vælg farve for spiller " + SpillerCounter.ToString());
                            Console.WriteLine("Du kan vælge mellem rød, gul, grøn og blå. Indtast farvevalg.");
                            bool[] hmm = { Farver.getRoedTaken, Farver.getGulTaken, Farver.getGroenTaken, Farver.getBlaaTaken };
                            string[] farver = {"rød", "gul", "grøn", "blå"};
                            string farve = Console.ReadLine();
                            for (int i = 0; i < hmm.Length; i++)
                            {
                                if (farve == farver[i] && hmm[i] == false)
                                {
                                    switch(farve)
                                    {
                                        case "rød": Farver.roedGet();
                                           break;
                                        case "gul": Farver.gulGet();
                                            break;
                                        case "grøn": Farver.groenGet();
                                            break;
                                        case "blå": Farver.blaaGet();
                                            break;
                                    }
                                    OpretSpiller(Spillere, farver[i]);
                                    SpillerCounter++;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du har valgt et ulovligt antal, indtast antal spillere");
                    }
                    /*Slut på oprettelse af spillere-------------------------------------------------------------------------*/
                    PrintSpillere(Spillere);
                    /*Start på at køre spillet-------------------------------------------------------------------------------*/
                    int NuværendeSpiller = 0;
                    while(NuværendeSpiller < antalSpillere)
                    {
                        Console.WriteLine("Det er nu spiller " + NuværendeSpiller.ToString());
                        if(Spillere[NuværendeSpiller].GetBrikStatus(0) == false)
                        {
                            Console.WriteLine("skriv kast for at kaste med terning");
                            string kast = Console.ReadLine();
                            if(kast == "kast")
                            {
                                int terningkast = Terning.TerningKast();
                                if(terningkast < 6)
                                {
                                    Console.WriteLine("desværre du slog under 6");
                                    NuværendeSpiller = SetNuværendeSpiller(NuværendeSpiller, antalSpillere);
                                }
                                else
                                {
                                    Console.WriteLine("Du slog 6 og har en brik ude");
                                    Spillere[NuværendeSpiller].SetBrikStatus(0, true);
                                    NuværendeSpiller = SetNuværendeSpiller(NuværendeSpiller, antalSpillere);
                                }
                            }
                        }
                        else
                        {
                            bool finished = Spillere[NuværendeSpiller].Finish();
                            if(finished == false)
                            {
                                //herfra køres spillet når en brik er ude og spilleren ikke er i mål.
                                Console.WriteLine("Du har en brik ude, skriv 'kast' for at kaste med terning");
                                string kast = Console.ReadLine();
                                if(kast == "kast")
                                {
                                    int terningslag = Terning.TerningKast();
                                    if(terningslag < 6)
                                    {
                                        Console.WriteLine("Du slog" + terningslag.ToString());
                                        RykBrik(terningslag, NuværendeSpiller, Spillere);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        int BrikBrætCounter = 0;
                                        Brik[] NuBrikker = Spillere[NuværendeSpiller].getBrikker;
                                        for (int i = 0; i < NuBrikker.Length; i++)
                                        {
                                            if(NuBrikker[i].GetSetPaaBraet == true)
                                            {
                                                BrikBrætCounter++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        if(BrikBrætCounter < Spillere[NuværendeSpiller].getBrikker.Length)
                                        {
                                            Console.WriteLine("Du har slået en sekser, og har " + BrikBrætCounter.ToString() + " brikker ude");
                                            Console.WriteLine("Tast f for at flytte næste brik ud, eller r for at rykke med en af de brikker der er ude");
                                            string brikvalg = Console.ReadLine();
                                            if(brikvalg == "f")
                                            {
                                                Spillere[NuværendeSpiller].SetBrikStatus(BrikBrætCounter, true);
                                            }
                                            else if(brikvalg == "r")
                                            {
                                                RykBrik(terningslag, NuværendeSpiller, Spillere);
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("ulovligt valg");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Du slog en sekser har alle brikker ude og kan kun rykke med de brikker du allerede har");
                                            RykBrik(terningslag, NuværendeSpiller, Spillere);
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Spiller " + NuværendeSpiller.ToString() + " er kommet i mål");
                                Console.ReadLine();
                            }
                            NuværendeSpiller = SetNuværendeSpiller(NuværendeSpiller, antalSpillere);
                        }
                    }
                }
                else
                {
                    spilIgang = false;
                }

            }
        }
        static void PrintSpillere(List<Spiller> spillere)
        {
            Console.WriteLine("Du har nu oprettet følgende spillere");
            for (int i = 0; i < spillere.Count; i++)
            {
                Console.Write("Spiller " + i.ToString() + " navn: " + spillere[i].GetSetNavn.ToString() + " farve: " + spillere[i].GetSetFarve.ToString() + " ");
                Console.Write("\n");
            }
        }
        static void OpretSpiller(List<Spiller> Spillere, string farve)
        {
            Console.WriteLine("Indtast navn");
            string Navn = Console.ReadLine();
            Spillere.Add(
            new Spiller
            {
                GetSetNavn = Navn,
                GetSetFarve = farve
            }
            ) ;
        }
        static int SetNuværendeSpiller(int nuværende, int antal)
        {
            if (nuværende == antal - 1)
            {
                nuværende = 0;
            }
            else
            {
                nuværende++;
            }
            return nuværende;
        }
        static void RykBrik(int terningSlag, int nuværendeSpiller, List<Spiller> spillerListe)
        {
            Brik[] Brikker = spillerListe[nuværendeSpiller].getBrikker;
            List<int> RykBrikker = new List<int>();
            for (int i = 0; i < Brikker.Length; i++)
            {
                if (Brikker[i].GetSetPaaBraet == true)
                {
                    Console.WriteLine("Du kan rykke med brik" + (i + 1).ToString() + "Som har position" + Brikker[i].GetSetFelt.ToString());
                    RykBrikker.Add(i + 1);
                }
            }
            Console.WriteLine("Vælg hvilken brik du vil rykke");
            string brikryk = Console.ReadLine();
            int BrikDerSkalRykkes = 0;
            for (int i = 0; i < RykBrikker.Count; i++)
            {
                if (int.Parse(brikryk) == RykBrikker[i])
                {
                    BrikDerSkalRykkes = RykBrikker[i];
                }
            }
            spillerListe[nuværendeSpiller].RykBrikker(BrikDerSkalRykkes - 1, terningSlag);
            Console.WriteLine("Brikken er nu på position" + spillerListe[nuværendeSpiller].BrikFelt(BrikDerSkalRykkes - 1));
        }
    }
}