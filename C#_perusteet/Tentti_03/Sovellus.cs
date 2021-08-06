using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Tentti03
{
    static class Sovellus
    {
        //Random- muuttuja
        static Random rnd = new Random();

        static void TeeYksiloKilpailu(double min, double max)
        {
            Write("Anna yksilökilpailun nimi: ");
            string kilpailunimi = ReadLine();
            YksiloKilpailu ykilpailu = new YksiloKilpailu {Nimi = kilpailunimi };   //Olion luonti

            while (true)    //Kysyy syötettä toistuvasti, kunnes tyhjä syöte
            {
                Write("Anna osallistujan nimi muodossa \"sukunimi etunimi\" (tyhjä lopettaa): ");
                string nimi = ReadLine();
                if (nimi == "")
                {
                    break;
                }
                //Lisää nimen ja arvotun tuloksen annettujen parametrien arvojen ja rnd muuttujan avulla Suoritukset listaan.
                ykilpailu.Suoritukset.Add(new Suoritus<Henkilo, double> {Osallistuja = new Henkilo {Nimi = nimi}, Tulos = min + rnd.NextDouble()*(max-min) });  
            }

            //Tuloksien julkistus
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine($"Kilpailun {kilpailunimi} tulokset:");
            foreach (var o in ykilpailu.Suoritukset)
            {
                WriteLine($"{o.Osallistuja.Nimi}, {Math.Round(o.Tulos, 2)}");   //Pyöristys kahden desimaalin tarkkuudelle
            }
            ResetColor();
            WriteLine();

        }
        static void TeeJoukkueKilpailu(int max)
        {
            Write("Anna joukkuekilpailun nimi: ");
            string kilpailunimi = ReadLine();
            JoukkueKilpailu jkilpailu = new JoukkueKilpailu {Nimi = kilpailunimi }; //Olion luonti

            while (true)    //Kysyy syötettä toistuvasti, kunnes tyhjä syöte
            {
                Write("Anna osallistujan nimi (tyhjä lopettaa): ");
                string nimi = ReadLine();
                if (nimi == "")
                {
                    break;
                }

                //Lisää nimen ja arvotun tuloksen annettujen parametrien arvojen ja rnd muuttujan avulla Suoritukset listaan.
                jkilpailu.Suoritukset.Add(new Suoritus<Joukkue, int> { Osallistuja = new Joukkue {Nimi = nimi }, Tulos = rnd.Next(0, max+1)});
            }

            //Tuloksien julkistus
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine($"Kilpailun {kilpailunimi} tulokset:");
            foreach (var o in jkilpailu.Suoritukset)
            {
                WriteLine($"{o.Osallistuja.Nimi}, {o.Tulos} pistettä");
            }
            ResetColor();
            WriteLine();
        }
        //Kopioidut koodit
        static double Desimaaliluku(string kehote, int tarkkuus = -1)
        {
            double paluu;
            Write($"{kehote} ");
            if (!double.TryParse(ReadLine(), out paluu))
            {
                throw new ApplicationException("Syöte ei ole kelvollinen desimaaliluku.");
            }
            return tarkkuus >= 0 ? Math.Round(paluu, tarkkuus) : paluu;
        }
        static double DesimaalilukuPakottaen(string kehote, int tarkkuus = -1)
        {
            do
            {
                try
                {
                    return Desimaaliluku(kehote, tarkkuus);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            } while (true);
        }
        static int Kokonaisluku(string kehote, int min = int.MinValue, int max = int.MaxValue)
        {
            int paluu;
            Write($"{kehote} ");
            if (!int.TryParse(ReadLine(), out paluu) || (paluu < min || paluu > max))
            {
                throw new ApplicationException("Syöte ei ole kelvollinen kokonaisluku." +
                    (min > int.MinValue ? ($" Minimi on {min}.") : "") +
                    (max < int.MaxValue ? ($" Maksimi on {max}.") : ""));
            }
            return paluu;
        }
        static int KokonaislukuPakottaen(string kehote, int min = int.MinValue, int max = int.MaxValue)
        {
            do
            {
                try
                {
                    return Kokonaisluku(kehote, min, max);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            } while (true);
        }
        public static void Aja()
        {
            while (true)    //Kysyy käyttäjältä toistuvasti kilpailun tyyppiä, sekä minimi-/maksimituloksia, kunnes annettu syöte on tyhjä
            {
                Write("Tehdäänkö yksilö- (y) vai joukkuekilpailu (j), tyhjä lopettaa: ");
                string paluu = ReadLine();

                if (paluu == "y")
                {
                    double min = DesimaalilukuPakottaen("Anna yksilökilpailun minimitulos: ");
                    double max = DesimaalilukuPakottaen("Anna yksilökilpailun maksimitulos: ");
                    TeeYksiloKilpailu(min, max);
                }
                if (paluu == "j")
                {
                    int max = KokonaislukuPakottaen("Anna joukkuekilpailun maksimipistemäärä: ");
                    TeeJoukkueKilpailu(max);
                }
                if (paluu == "")
                {
                    break;
                }
            }
        }
    }
}
