using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti02
{
    class Noppa
    {
        //Staattinen muuttuja
        static Random NOPPA = new Random();

        //Automaattiset ominaisuudet
        public int Lukema { get; set; }
        public int HeittoLkm { get; set; }

        //Konstruktori
        public Noppa(int heittolkm = 0)
        {
            HeittoLkm = heittolkm;
        }

        //Metodi noppien heittämiseen - palauttaa Lukeman
        public int Heita()
        {
            Lukema = NOPPA.Next(1,7);
            HeittoLkm += 1;
            return Lukema;
        }
    }
}
