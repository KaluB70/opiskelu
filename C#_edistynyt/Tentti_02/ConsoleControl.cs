using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentti_02
{
    class ConsoleControl
    {
        //Automaattiset ominaisuudet
        public List<string> Items { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ConsoleColor BackColor { get; set; }
        public ConsoleColor TextColor { get; set; }

        //Konstruktori - asettaa konsolin koon ja datan omiin ominaisuuksiinsa
        public ConsoleControl(int col, int row, int width, int height)
        {
            Column = col;
            Row = row;
            Width = width;
            Height = height;
            BackColor = Console.BackgroundColor;
            TextColor = Console.ForegroundColor;
            Items = null;
        }

        //Metodi, joka tyhjentää olion määrittelemän alueen
        public void Clear()
        {
            int vasen = Console.CursorLeft;
            int yla = Console.CursorTop;
            Console.SetCursorPosition(Column, Row);
            //Looppi, joka tyhjentää määritellyn alueen välilyöntien avulla
            for (int i = 0; i < Height; i++)
            {
                for (int i1 = 0; i1 < Width; i1++)
                {
                    Console.Write(' ');
                }
                Console.CursorTop++;
                Console.CursorLeft = Column;
            }
            Console.WriteLine();
            Console.SetCursorPosition(vasen, yla);
        }
        //Metodi Draw, joka tulostaa pyydetyn listan tiedot omaan paikkaansa
        //Palauttaa kursorin paikan ja tekstin/taustan värit alkuperäisiin arvoihinsa suorituksen jälkeen
        public void Draw()
        {
            //Alustus
            Clear();
            int vasen = Console.CursorLeft;
            int yla = Console.CursorTop;
            ConsoleColor tekstivari = Console.ForegroundColor;
            ConsoleColor taustavari = Console.BackgroundColor;
            Console.SetCursorPosition(Column, Row);
            Console.BackgroundColor = BackColor;
            //Looppi, joka liikuttaa kursoria joka "syklin" jälkeen yhden alemmas listan jäsenten tulostusta varten
            for (int i = 0; i < Items.Count; i++)
            {
                Console.ForegroundColor = TextColor; 
                Console.Write(Items[i].PadRight(Width));
                Console.CursorTop++;
                Console.CursorLeft = Column;
                Console.ForegroundColor = tekstivari;

            }
            Console.SetCursorPosition(vasen, yla);
            Console.BackgroundColor = taustavari;
        }
    }
}
