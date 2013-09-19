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
        private int postSellInQuality;

        public InventoryItemConstantImprovement(Item newItem, int qualityJump, int sellInQualityJump)
        {
            this.item = newItem;
            this.normalQuality = qualityJump;
            this.postSellInQuality = sellInQualityJump;
        }

        public void updateQuality()
        {
            if (this.item.Quality < Constants.maxQuality)
            {
                if (this.item.SellIn > Constants.SellInPassed)
                {
                    this.item.Quality += this.normalQuality;
                }
                else {
                    this.item.Quality += this.postSellInQuality;
                }
                if (this.item.Quality > Constants.maxQuality) this.item.Quality = Constants.maxQuality;
            }            
        }

        public void updateSellIn()
        {
            this.item.SellIn -= 1;
        }
    }
}
