using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti02
{
    class Peli
    {
        //Automaattiset ominaisuudet
        public Pelaaja Pelaaja1 { get; set; }
        public Pelaaja Pelaaja2 { get; set; }
        public int KierrosLkm { get; set; }
        public int VoitonPisteRaja { get; }
        public Pelaaja Voittaja 
        {
            get
            {
                //Voittajan tarkastelu
                if (Pelaaja1.Pisteet == VoitonPisteRaja)
                {
                    return Pelaaja1;
                }
                if(Pelaaja2.Pisteet == VoitonPisteRaja)
                {
                    return Pelaaja2;
                }
                else
                {
                    return null;
                }
            }
        }

        //Konstruktori
        public Peli(Pelaaja pelaaja1, Pelaaja pelaaja2, int voitonpisteraja)
        {
            Pelaaja1 = pelaaja1;
            Pelaaja2 = pelaaja2;
            VoitonPisteRaja = voitonpisteraja;
            KierrosLkm = 0;
        }

        //Metodi noppien heittämiselle 2 kertaa ja tulosten tulostaminen
        private int NoppienHeitto(Pelaaja pelaaja)
        {
            int tulos1 = pelaaja.Noppa.Heita();
            int tulos2 = pelaaja.Noppa.Heita();
            int summa = tulos1 + tulos2;
            //Console.WriteLine($"{ pelaaja.Nimi}: {tulos1} + {tulos2} = {summa}");
            return summa;
        }

        //Metodi kierrosten pelaamiselle ja pistemäärien muuttamiselle tuloksen mukaisesti
        public void PelaaKierros()
        {
            KierrosLkm += 1;
            //Console.WriteLine($"Heittokierros {KierrosLkm}");
            int tulosp1 = NoppienHeitto(Pelaaja1);
            int tulosp2 = NoppienHeitto(Pelaaja2);
            if (tulosp1 > tulosp2)
            {
                Pelaaja1.Pisteet += 1;
                Pelaaja2.Pisteet = 0;
            }
            else
            {
                if (tulosp2 > tulosp1)
                {
                    Pelaaja2.Pisteet += 1;
                    Pelaaja1.Pisteet = 0;
                }
            }
        }
    }
}
