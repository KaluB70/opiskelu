using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tentti01
{
    class Esine : INimi, IComparable<Esine>
    {
        // Kenttämuuttujat
        private double _paino;

        // Ominaisuudet
        public string Nimi { get; set; }
        public double Paino
        {
            get => _paino;
            set
            {
                if (value < 0)
                {
                    // Paino yritetään asettaa negatiiviseksi, aiheutetaan poikkeus.
                    throw new ArgumentOutOfRangeException("value", "Esineen paino ei voi olla negatiivinen.");
                }
                else
                {
                    // Pyöristetään talletettava arvo kolmen desimaalin tarkkuuteen ja asetetaan se muuttujaan.
                    _paino = Math.Round(value, 3);
                }
            }
        }
        public int PainoG => (int)(Paino * 1000); // Muutetaan paino grammoiksi kertomalla se tuhannella ja sitten palautetaan se kokonaislukuna. (Voidaan palauttaa kokonaislukuna, koska Paino talletetaan aina gramman tarkkuudella.)


        // Metodit
        public int CompareTo(Esine other)
        {
            // Verrataan parametrin Esineen painoa tämän esineen painoon.
            return Paino.CompareTo(other?.Paino);
        }
        public override string ToString()
        {
            // Esineen nimi ja paino
            return $"{Nimi} {Paino} kg";
        }
    }
}
