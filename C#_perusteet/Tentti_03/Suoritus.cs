using System;
using System.Collections.Generic;
using System.Text;

namespace Tentti03
{
    class Suoritus<TOsallistuja,TTulos>
    {
        //Automaattiset ominaisuudet - määrittyy osallistujan ja tuloksen tyypin mukaan
        public TOsallistuja Osallistuja { get; set; }
        public TTulos Tulos { get; set; }
    }
}
