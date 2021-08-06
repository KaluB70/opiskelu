using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti03
{
    class Henkilo : IOsallistuja
    {
        //Automaattiset ominaisuudet
        public int Id { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }

        //Ominaisuus, joka palauttaa henkilön koko nimen (sukunimi etunimi)
        public string Nimi
        {
            get {
                return $"{Sukunimi} {Etunimi}";
            }
            set {
                string[] nimi = value.Split();
                if (nimi.Length == 2)
                {
                    Sukunimi = nimi[0];
                    Etunimi = nimi[1];
                }
                else
                {
                    throw new Exception("Henkilön nimi on oltava muodossa sukunimi etunimi.");
                }
            }
        }
    }
}
