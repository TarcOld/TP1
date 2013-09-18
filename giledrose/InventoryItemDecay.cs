using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiuba.Tecnicas.Giledrose
{
    class InventoryItemDecay : IInventoryItem
    {
        private Item item;
        private int normalQuality;
        private int postSellInQuality;

        public InventoryItemDecay(Item newItem, int normalQualityJump, int postSellInQualityJump)
        {
            this.item = newItem;
            this.normalQuality = normalQualityJump;
            this.postSellInQuality = postSellInQualityJump;
        }

        public void updateQuality()
        {
            if (this.item.Quality > Constants.minQuality)
            {
                if (item.SellIn > 0)
                {
                    this.item.Quality -= this.normalQuality;
                }
                else
                {
                    this.item.Quality -= this.postSellInQuality;
                }
                if (this.item.Quality < Constants.minQuality) this.item.Quality = Constants.minQuality;
            }
        }

        public void updateSellIn()
        {
            this.item.SellIn -= 1;
        }
    }
}
