using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiuba.Tecnicas.Giledrose
{
    class ItemManager
    {
        private List<IInventoryItem> inventoryItems;        

        public ItemManager(IEnumerable<Item> items)
        {
            this.inventoryItems = new List<IInventoryItem> {};
            foreach (var item in items)
            {
                IInventoryItem invItem = this.createItem(item);
                inventoryItems.Add(invItem);
            }


        }

        private IInventoryItem createItem(Item item)
        {
            if (isLegendary(item.Name)) return new InventoryItemLegendary(item);
            if (isConcert(item.Name)) return new InventoryItemConcert(item);
            if (isConstantImprovement(item.Name)) return new InventoryItemConstantImprovement(item, Constants.normalQualityJump,Constants.doubleQualityJump);
            if (isDoubleDecay(item.Name)) return new InventoryItemDecay(item, 2 * Constants.normalQualityJump, 2 * Constants.doubleQualityJump);
            return new InventoryItemDecay(item,Constants.normalQualityJump,Constants.doubleQualityJump);
        }

        public void updateItems()
        {
            for (int i = 0; i < this.inventoryItems.Count; i++)
            {
                this.inventoryItems[i].updateQuality();
                this.inventoryItems[i].updateSellIn();
            }
        }


        private bool isLegendary(string itemName)
        {
            List<string> list = new List<string>
            {
                "Sulfuras"
            };
            return inList(itemName, list);
        }

        private bool isConstantImprovement(string itemName)
        {
            List<string> list = new List<string>
            {
                "Aged Brie"
            };
            return inList(itemName, list);            
        }

        private bool isConcert(string itemName)
        {
            List<string> list = new List<string>
            {
                "Backstage passes"
            };
            return inList(itemName, list);
        }

        private bool isDoubleDecay(string itemName)
        {
            List<string> list = new List<string>
            {
                "Conjured"
            };
            return inList(itemName, list);
        }

        private bool inList(string name, List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (name.Contains(list[i])) return true;
            }
            return false;
        }

        
    }
}
