using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentti_03
{
    public class MenuItem
    {
        //Automaattiset ominaisuudet
        public int Id { get; set; }
        public string Name { get; set; }

        //Tapahtuma
        public event EventHandler<MenuItemEventArgs> ItemSelected;

        //Select- metodi
        //=> Jos ItemSelected != null => suoritetaan ItemSelected:n sisältämä metodi
        public void Select()
        {
            ItemSelected?.Invoke(this, new MenuItemEventArgs { ItemId = Id });
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
