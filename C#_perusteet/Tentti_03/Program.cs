using System;

namespace Tentti03
{
    class Program
    {
        static void Main()
        {
            //Ohjelman suoritus vikasietoisena
            try
            {
                Console.InputEncoding = System.Text.Encoding.Unicode; //Itselle tarpeellinen koodirivi - tuntemattomasta syystä johtuen käyttäjän kirjoittaman syötteen  
                                                                      //lukemisen aikana kirjoitetut Ä,Å ja Ö kirjaimet jäävät outputissa kokonaan pois ilman ko. riviä. 
                Sovellus.Aja();
            }
            //Virheilmoitukset
            catch (Exception e)
            {
                Console.WriteLine("Ohjelman suoritus päättyi virheeseen.");
                Console.WriteLine($"Virhe: {e.Message}");
            }
        }
    }
}
