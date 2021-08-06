using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti01
{
    class Laatikko : INimi
    {
        // Ominaisuudet
        public string Nimi { get; set; }
        public List<Esine> Esineet { get; set; }
        public int Maksimipaino { get; set; }
        public double Paino
        {
            get
            {
                // Lasketaan listalla olevien esineiden painot yhteen, pyöristetään summa kolmen desimaalin (yhden gramman) tarkkuuteen ja palautetaan se.
                double summa = 0;
                foreach (Esine esine in Esineet)
                {
                    summa += esine.Paino;
                }
                return Math.Round(summa, 3);
            }
        }
        public Esine PainavinEsine
        {
            get
            {
                if (Esineet.Count == 0)
                {
                    // Lista on tyhjä, joten painavinta elementtiä ei voi määrittää.
                    return null;
                }

                // Lajitellaan lista esineistä (kevyimmästä painavimpaan) ja palautetaan viimeinen (painavin) esine.
                Esineet.Sort();
                return Esineet[Esineet.Count - 1];
            }
        }

        // Konstruktori
        public Laatikko(int maksimipaino = 100)
        {
            // Asetetaan laatikon maksimipaino (oletus 100) ja esineiden listaan asetetaan uusi tyhjä lista
            Maksimipaino = maksimipaino;
            Esineet = new List<Esine>();
        }

        // Metodit
        public void LisaaEsine(Esine esine)
        {
            if (Paino + esine.Paino <= Maksimipaino)
            {
                // Laatikon paino lisättävän esineen kanssa ei ylitä sallittua rajaa, joten esine voidaan lisätä laatikkoon.
                Esineet.Add(esine);
            }
            else
            {
                // Maksimipaino ylittyisi, aiheutetaan poikkeus.
                throw new ArgumentException($"Laatikkoon {Nimi} ei voitu lisätä, koska maksimipaino olisi ylittynyt.");
            }
        }
        public override string ToString()
        {
            // Laatikon nimi ja paino
            return $"{Nimi} {Paino} kg";
        }
    }
}
