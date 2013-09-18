using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiuba.Tecnicas.Giledrose
{
    class InventoryItemConstantImprovement : IInventoryItem
    {
        private Item item;
        private int normalQuality;

        public InventoryItemConstantImprovement(Item newItem, int qualityJump)
        {
            this.item = newItem;
            this.normalQuality = qualityJump;
        }

        public void updateQuality()
        {
            if (this.item.Quality < Constants.maxQuality)
            {
                this.item.Quality += this.normalQuality;
                if (this.item.Quality > Constants.maxQuality) this.item.Quality = Constants.maxQuality;
            }            
        }

        public void updateSellIn()
        {
            this.item.SellIn -= 1;
        }
    }
}
