using System;

namespace Tentti_03
{
    class Program
    {
        static void Main()
        {
            //Itselle tarpeellinen koodinpätkä (muuten käyttäjän syöttämät ä,ö ja å kirjaimet katoavat tulostuksesta)
            //Todennäköisesti turha pätkä muille, mutta ei silti vaikuta suoritukseen
            Console.InputEncoding = System.Text.Encoding.Unicode;

            //Ohjelman suoritus
            Application.Run();
        }
    }
}
