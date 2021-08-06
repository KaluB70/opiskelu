using System;

namespace Tentti02
{
    class Program
    {
        static void Main()
        {
            //Sovelluksen ajaminen vikasietoisesti
            try
            {
                Sovellus.Aja();
            }
            catch (Exception e)
            {
                //Virheilmoitus
                Console.WriteLine("Ohjelman suoritus päättyi virheeseen.");
                Console.WriteLine($"Virhe: {e.Message}");
            }
        }
    }
}
