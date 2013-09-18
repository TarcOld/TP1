using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiuba.Tecnicas.Giledrose
{
    class InventoryItemConcert : IInventoryItem
    {
        private Item item;        

        public InventoryItemConcert(Item newItem)
        {
            this.item = newItem;
        }

        public void updateQuality()
        {
            if (this.item.SellIn > 0)
            {
                this.item.Quality += this.getIncrease();
                if (this.item.Quality > Constants.maxQuality) this.item.Quality = Constants.maxQuality;
            }
            else
            {
                this.item.Quality = Constants.minQuality;
            }
        }

        public void updateSellIn()
        {
            this.item.SellIn -= 1;
        }

        private int getIncrease()
        {
            if (this.item.SellIn > Constants.concertNearSellin) return Constants.normalQualityJump;
            if (this.item.SellIn > Constants.concertWeekSellIn) return Constants.doubleQualityJump;
            return Constants.tripleQualityJump;
        }
    }
}
