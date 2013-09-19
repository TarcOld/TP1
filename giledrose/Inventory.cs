using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiuba.Tecnicas.Giledrose
{
    public class Inventory
    {
        private readonly IEnumerable<Item> items;
        private ItemManager manager;

        public Inventory(IEnumerable<Item> items) 
        {
            manager = new ItemManager(items);
            this.items = items;            
        }

        public Inventory() 
        {
            items = new List<Item>
            {
                new Item("+5 Dexterity Vest", 10, 20),
                new Item("Aged Brie", 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new Item("Sulfuras, Hand of Ragnaros", 0, 80),
                new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new Item("Conjured Mana Cake", 3, 6)
            };
            manager = new ItemManager(items);               
        }

        public void updateQuality()
        {
            manager.updateItems();
        }
    }
}
