using System;
using static System.Console;

namespace Tentti01
{
    class Program
    {
        static void Main()
        {
            Console.Title = "ISBN - Tarkastaja";                                    //Komentekehotteen otsikkorivin muutos
            int virheelliset = 0;                                                   //Tallettaa virheellisten ISBN-syötteiden kplmäärän, jos oikean pituinen ja oikeaa muotoa
            int kelvolliset = 0;                                                    //Tallettaa kelvollisten ISBN-syötteiden kplmäärän
            bool looppi = true;                                                     //Käynnistetään looppi
            while (looppi)
            {
                Write("Anna numerosarja: ");
                string annettuSyote = ReadLine();                                  
                if (annettuSyote.Length == 0)
                {
                    looppi = false;                                                 //Pysäyttää ohjelman, jos syöte on pelkkä Enter-painallus
                    WriteLine();
                    WriteLine($"Kelvollisia numerosarjoja {kelvolliset} kpl");      //Ilmoittaa lopuksi ko. kappalemäärät
                    WriteLine($"Virheellisiä numerosarjoja {virheelliset} kpl");
                    ReadLine();
                }
                else
                {
                    try                                                             //Testataan, onko syötteessä pelkkiä numeroita
                    {
                        double.Parse(annettuSyote);
                        if (annettuSyote.Length == 13)                              //Testataan syötteen pituus
                        {
                            
                            bool tarkistus = Tarkistusnumero(annettuSyote);         //Vertaillaan laskettua tarkistusnumeroa syötettyyn tarkistusnumeroon
                            if (tarkistus == true)
                            {
                                WriteLine("ISBN");
                                kelvolliset++;
                            }
                            else
                            {
                                ForegroundColor = ConsoleColor.DarkYellow;          //Virheilmoituksia (Värin vaihto keltaiseksi ja takaisin harmaaksi)
                                WriteLine("Virheellinen tarkiste.");
                                ForegroundColor = ConsoleColor.Gray;
                                virheelliset++;
                            }
                        }
                        else        
                        {
                            ForegroundColor = ConsoleColor.DarkYellow;
                            WriteLine("Syötteen pituus on virheellinen.");
                            ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (Exception)
                    {
                        ForegroundColor = ConsoleColor.DarkYellow;
                        WriteLine("Syötteen muoto on virheellinen.");
                        ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }
        //Tarkistaja-metodi laskee annetusta syötteestä tarkistusnumeron
        static int Tarkistaja(string syotettyNroSarja)
        {   
            
            
            int summa = 0;                                                          //Tallettaa jokaisen laskutoimituksen tulon
            int kerroin = 1;                                                        //Muuttuu jokaisen laskutoimituksen jälkeen 1 -> 3 ja päinvastoin
            string tarkistettavaNroSarja = syotettyNroSarja.Substring(0, 12);       //Otetaan huomioon vain 12 ensimmäistä merkkiä

            foreach (char x in tarkistettavaNroSarja)
            {                                                                       
                int tarkistettavaLuku = int.Parse(x.ToString());                    //Merkin tyyppimuunnos kokonaisluvuksi        
                if (kerroin == 1)                                                   //Laskutoimitus - tarkistettavaLuku sisältää yhden merkin, joka on kokonaisluku           
                {                                                                   //Foreachin edetessä sekä kerroin, että muuttuja(seuraava merkki numerosarjasta) muuttuvat
                    summa += tarkistettavaLuku * kerroin;
                    kerroin = 3;
                }
                else
                {
                    summa += tarkistettavaLuku * kerroin;
                    kerroin = 1;
                }
            }
            if (10 - (summa % 10) == 10)                                            //Tarkistusnumeron laskeminen. Jos tulos == 10, palautetaan 0. Muuten palautetaan tulos.
            {
                return 0;
            }
            else
            {
                return 10 - (summa % 10);
            }
        }
        //Tarkistusnumero-metodi vertailee laskettua tarkistusnumeroa, sekä annettua tarkistusnumeroa, ja palauttaa bool-arvon, jota vertaillaan.
        static bool Tarkistusnumero(string annettuNroSarja)
        {
            int tarkistusNro = int.Parse(annettuNroSarja[12].ToString());           //Annetun syötteen viimeinen numero
            if (tarkistusNro == Tarkistaja(annettuNroSarja))                        //Tarkistaja(annettuNroSarja) on syötteestä laskettu tarkistusnumero
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
