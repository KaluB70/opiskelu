using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti02
{
    //INimi rajapinnan toteutus
    class Pelaaja : INimi
    {
        //Automaattiset ominaisuudet
        public string Nimi { get; set; }
        public int Pisteet { get; set; }
        public Noppa Noppa { get; set; }

        //Konstruktori
        public Pelaaja(string nimi)
        {
            Nimi = nimi;
            Pisteet = 0;
            Noppa = new Noppa();
        }
    }
}
