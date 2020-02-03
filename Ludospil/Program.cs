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
            bool spilIgang = true;
            Terning Terning = new Terning();
            Farve Farver = new Farve();
            List<Spiller> Spillere = new List<Spiller>();
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
                            string farve = Console.ReadLine();
                            if(farve == "rød" || farve == "gul" || farve == "grøn" || farve == "blå")
                            {
                                if(farve == "rød" && Farver.getRoedTaken == false)
                                {
                                    Console.WriteLine("Indtast navn");
                                    string Navn = Console.ReadLine();
                                    Spillere.Add(
                                        new Spiller
                                        {
                                            GetSetNavn = Navn,
                                            GetSetFarve = Farver.roedGet()
                                        }
                                        ) ;
                                    SpillerCounter++;
                                }
                                else if(farve == "gul" && Farver.getGulTaken == false)
                                {
                                    Console.WriteLine("Indtast navn");
                                    string Navn = Console.ReadLine();
                                    Spillere.Add(
                                    new Spiller
                                    {
                                        GetSetNavn = Navn,
                                        GetSetFarve = Farver.gulGet()
                                    }
                                    );
                                    SpillerCounter++;
                                }
                                else if(farve == "grøn" && Farver.getGroenTaken == false)
                                {
                                    Console.WriteLine("Indtast navn");
                                    string Navn = Console.ReadLine();
                                    Spillere.Add(
                                    new Spiller
                                    {
                                        GetSetNavn = Navn,
                                        GetSetFarve = Farver.groenGet()
                                    }
                                    );
                                    SpillerCounter++;
                                }
                                else if(farve == "blå" && Farver.getBlaaTaken == false)
                                {
                                    Console.WriteLine("Indtast navn");
                                    string Navn = Console.ReadLine();
                                    Spillere.Add(
                                    new Spiller
                                    {
                                        GetSetNavn = Navn,
                                        GetSetFarve = Farver.blaaGet()
                                    }
                                    );
                                    SpillerCounter++;
                                }
                                else
                                {
                                    Console.WriteLine("Farven er allerede taget");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du har valgt et ulovligt antal, indtast antal spillere");
                    }
                    Console.WriteLine("Du har nu oprettet følgende spillere");
                    for (int i = 0; i < Spillere.Count; i++)
                    {
                        Console.Write("Spiller " + i.ToString() + " navn: " + Spillere[i].GetSetNavn.ToString() + " farve: " + Spillere[i].GetSetFarve.ToString() + " ");
                        Console.Write("\n");
                    }
                    int NuværendeSpiller = 0;
                    //de skal skiftes til at slå med terning.
                    while(true)
                    {
                        if(NuværendeSpiller < antalSpillere)
                        {
                            Console.WriteLine("Det er nu spiller " + (NuværendeSpiller + 1).ToString() + "s tur");
                            /*Skal validere på om spilleren har en brik ude.*/
                            if(Spillere[NuværendeSpiller].Brik1Braet == true)
                            {
                                Console.WriteLine("Når en brik er ude så går det for sig");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Du har ingen brikker ude. skriv 'kast' for at kaste med terning");
                                Console.WriteLine("Hvis du slår en sekser rykker du en brik ud");
                                string kast = Console.ReadLine();
                                if(kast == "kast")
                                {
                                    int terningKast = Terning.TerningKast();
                                    if(terningKast < 6)
                                    {
                                        Console.WriteLine("Desværre du slog under seks");
                                        NuværendeSpiller++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Du slog 6 og har nu en brik ude");
                                        Spillere[NuværendeSpiller].Brik1Braet = true;
                                        NuværendeSpiller++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            NuværendeSpiller = 0;
                        }
                    }
                }
                else
                {
                    spilIgang = false;
                }
            }
        }
    }
}