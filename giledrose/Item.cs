using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiuba.Tecnicas.Giledrose
{
    public class Item
    {
        public Item(String name, int sellIn, int quality)
        {
            this.Name = name;
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public string Name
        {
            get;
            set;

        }

        public int SellIn
        {
            get;
            set;
        }

        public int Quality
        {
            get;
            set;
        }
    }
}
