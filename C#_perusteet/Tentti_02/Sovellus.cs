using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti02
{
    static class Sovellus
    {
        public static void Aja()
        {
            //Alkuteksti
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Noppa-peli");
            Console.ResetColor();

            //Nimien kysely ja olioiden luominen
            Console.Write("Pelaajan 1 nimi: ");
            string nimi1 = Console.ReadLine();
            Console.Write("Pelaajan 2 nimi: ");
            string nimi2 = Console.ReadLine();

            Pelaaja p1 = new Pelaaja(nimi1);
            Pelaaja p2 = new Pelaaja(nimi2);

            //Noppien luonti (toimii ilmankin, koska luodaan jo Pelaaja-luokan konstruktorissa)
            p1.Noppa = new Noppa();
            p2.Noppa = new Noppa();

            Peli peli = new Peli(p1, p2, 50);

            //Looppi kierrosten pelaamiseen niin kauan, kun voittaja löytyy
            do
            {
                peli.PelaaKierros();
            }
            while (peli.Voittaja == null);

            //Voittajan julistus
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine($"Pelin voittaja on {peli.Voittaja.Nimi} ja noppia heitettiin {peli.KierrosLkm} kertaa!");
            Console.ResetColor();
        }
    }
}
