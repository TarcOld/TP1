using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiuba.Tecnicas.Giledrose
{
    class InventoryItemLegendary : IInventoryItem
    {
        private Item item;

        public InventoryItemLegendary(Item newItem)
        {
            this.item = newItem;
        }

        public void updateQuality(){

        }

        public void updateSellIn()
        {
            
        }
    }
}
