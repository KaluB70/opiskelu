using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti03
{
    class Kilpailu<TOsallistuja, TTulos>
    {
        //Automaattiset ominaisuudet
        public string Nimi { get; set; }
        public List<Suoritus<TOsallistuja, TTulos>> Suoritukset { get; set; }

        //Konstruktori - Luo uuden listan Suoritus luokasta
        public Kilpailu()
        {
            Suoritukset = new List<Suoritus<TOsallistuja, TTulos>>();
        }
    }
}
