using System;
using System.Collections.Generic;
using Helpers;

namespace Tentti01
{
    class Program
    {
        static void Main()
        {
            // Luodaan lista laatikoista
            List<Laatikko> laatikot = new List<Laatikko>();

            Console.WriteLine("Tehdään laatikot");

            // Toistetaan kunnes käyttäjä antaa laatikon nimeksi tyhjän merkkijonon.
            while (true)
            {
                // Kysytään laatikon nimeä.
                string laatikkoNimi = Syote.Merkkijono("Anna laatikon nimi (tyhjä lopettaa):");

                if (laatikkoNimi == "")
                {
                    // Käyttäjä antoi laatikon nimeksi tyhjän merkkijonon, lopetetaan.
                    break;
                }

                // Luodaan uusi laatikko annetulla nimellä ja lisätään se laatikkolistalle.
                Laatikko laatikko = new Laatikko() { Nimi = laatikkoNimi };
                laatikot.Add(laatikko);

                Console.WriteLine("Lisätään laatikkoon esineitä");

                // Kysytään laatikkoon laitettavia esineitä, kunnen käyttäjä antaa esineen nimeksi tyhjän merkkijonon.
                while (true)
                {
                    // Kysytään esineen nimeä.
                    string esineNimi = Syote.Merkkijono("Anna esineen nimi (tyhjä lopettaa):");

                    if (esineNimi == "")
                    {
                        // Käyttäjä antoi esineen nimeksi tyhjän merkkijonon, lopetetaan tämän laatikon täyttäminen ja siirrytään seuraavan laatikon luomiseen.
                        break;
                    }

                    // Kysytään esineen painoa ja lukumäärää.
                    double esinePaino = Syote.DesimaalilukuPakottaen("Anna esineen paino (kg):");
                    int esineMaara = Syote.KokonaislukuPakottaen("Lisättävä määrä:");

                    // Luodaan muuttuja pitämään kirjaa lisättyjen esineiden määrästä.
                    int esineitaLisatty = 0;
                    try
                    {
                        // Lisätään samanlaisia esineitä annetulla nimellä ja painolla, kunnes joko esineitä on lisätty tarvittava määrä, tai laatikon painoraja tulee vastaan (jolloin try:n suorittaminen loppuu kesken ja tulostetaan virheilmoitus).
                        // Kummassakin tapauksessa tulostetaan laatikkoon lisättyjen esineiden lukumäärä.
                        for (esineitaLisatty = 0; esineitaLisatty < esineMaara; esineitaLisatty++)
                        {
                            laatikko.LisaaEsine(new Esine() { Nimi = esineNimi, Paino = esinePaino });
                        }
                    }
                    catch (Exception e)
                    {
                        // Tapahtui virhe (luultavasta joko laatikon painoraja tuli vastaan tai esineen painoksi yritettiin asettaa negatiivinen arvo), tulostetaan virheteksti.
                        Console.WriteLine("Virhe: " + e.Message);
                    }

                    // Tulostetaan laatikkoon lisättyjen esineiden nimi ja lukumäärä.
                    Console.WriteLine($"Esinettä {esineNimi} lisättiin {esineitaLisatty} kpl.");
                }
            }

            // Tulostetaan jokaisen laatikon nimi, sen sisältämien esineiden lukumäärä ja laatikon painavimman esineen nimi ja paino.
            foreach (Laatikko laatikko in laatikot)
            {
                Console.WriteLine($"\nLaatikko {laatikko}");
                Console.WriteLine($"Esineitä {laatikko.Esineet.Count} kpl.");
                Console.WriteLine($"Painavin esine {laatikko.PainavinEsine}.");
            }
        }
    }
}
