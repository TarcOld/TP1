using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Fiuba.Tecnicas.Giledrose;


using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Collections;


namespace Giledrose.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class GiledroseTest
    {
        List<Item> itemsUpdate;
        List<Item> itemsOriginal;
        Inventory inventory;        

        public GiledroseTest()
        {
            this.itemsOriginal = getInventory();
            this.itemsUpdate = getInventory();
            this.inventory = new Inventory(itemsUpdate);
            this.inventory.updateQuality();
        }

        private List<Item> getInventory()
        {
            List<Item> itemList = new List<Item>
            {
                new Item("Regular Product", 10, 10),
                new Item("Sulfuras, Hand of Ragnaros", 10, Constants.legendaryQuality),
                new Item("Sulfuras, Hand of Ragnaros", Constants.SellInPassed, Constants.legendaryQuality),
                new Item("Aged Brie", 40, 40),
                new Item("Aged Brie", 10, 50),
                new Item("Aged Brie", Constants.SellInPassed, 48),
                new Item("Backstage passes to a TAFKAL80ETC concert", 30, 10),
                new Item("Backstage passes to a TAFKAL80ETC concert", Constants.concertNearSellin, 40),
                new Item("Backstage passes to a TAFKAL80ETC concert", Constants.concertWeekSellIn, 45),
                new Item("Backstage passes to a TAFKAL80ETC concert", Constants.SellInPassed, 47),
                new Item("+5 Dexterity Vest", 0, 10),
                new Item("+5 Dexterity Vest", 0, 0),
                new Item("Conjured Mana Cake", 5, 20),
                new Item("Conjured Mana Cake",Constants.SellInPassed,20),
            };
            return itemList;

        }

        [TestMethod]
        public void TestRegularProduct()
        {
            int previousSellIn = this.itemsOriginal[0].SellIn;
            int previousQuality = this.itemsOriginal[0].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[0].SellIn);
            Assert.AreEqual(previousQuality - 1, this.itemsUpdate[0].Quality);
        }


        [TestMethod]
        public void TestLegendarySulfurasNormalSellin()
        {
            int previousSellIn = this.itemsOriginal[1].SellIn;            
            Assert.AreEqual(previousSellIn, this.itemsUpdate[1].SellIn);
            Assert.AreEqual(Constants.legendaryQuality, this.itemsUpdate[1].Quality);
        }

        [TestMethod]
        public void TestLegendarySulfurasPastSellin()
        {
            int previousSellIn = this.itemsOriginal[2].SellIn;
            Assert.AreEqual(previousSellIn, this.itemsUpdate[2].SellIn);
            Assert.AreEqual(Constants.legendaryQuality, this.itemsUpdate[2].Quality);
        }

        [TestMethod]
        public void TestAgedBrieNormal()
        {
            int previousSellIn = this.itemsOriginal[3].SellIn;
            int previousQuality = this.itemsOriginal[3].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[3].SellIn);
            Assert.AreEqual(previousQuality + 1, this.itemsUpdate[3].Quality);
        }

        [TestMethod]
        public void TestAgedBrieMaxQuality()
        {
            int previousSellIn = this.itemsOriginal[4].SellIn;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[4].SellIn);
            Assert.AreEqual(Constants.maxQuality, this.itemsUpdate[4].Quality);
        }

        [TestMethod]
        public void TestAgedBrieMinSeelIn()
        {
            int previousSellIn = this.itemsOriginal[5].SellIn;
            int previousQuality = this.itemsOriginal[5].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[5].SellIn);
            Assert.AreEqual(previousQuality + Constants.doubleQualityJump, this.itemsUpdate[5].Quality);
        }

        [TestMethod]
        public void TestBackstageNormal()
        {
            int previousSellIn = this.itemsOriginal[6].SellIn;
            int previousQuality = this.itemsOriginal[6].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[6].SellIn);
            Assert.AreEqual(previousQuality + Constants.normalQualityJump, this.itemsUpdate[6].Quality);
        }

        [TestMethod]
        public void TestBackstageDouble()
        {
            int previousSellIn = this.itemsOriginal[7].SellIn;
            int previousQuality = this.itemsOriginal[7].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[7].SellIn);
            Assert.AreEqual(previousQuality + Constants.doubleQualityJump, this.itemsUpdate[7].Quality);
        }

        [TestMethod]
        public void TestBackstageTriple()
        {
            int previousSellIn = this.itemsOriginal[8].SellIn;
            int previousQuality = this.itemsOriginal[8].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[8].SellIn);
            Assert.AreEqual(previousQuality + Constants.tripleQualityJump, this.itemsUpdate[8].Quality);
        }

        [TestMethod]
        public void TestBackstagePastSellIn()
        {
            int previousSellIn = this.itemsOriginal[9].SellIn;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[9].SellIn);
            Assert.AreEqual(0, this.itemsUpdate[9].Quality);
        }

        [TestMethod]
        public void TestNormalItemPastSellIn()
        {
            int previousSellIn = this.itemsOriginal[10].SellIn;
            int previousQuality = this.itemsOriginal[10].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[10].SellIn);
            Assert.AreEqual(previousQuality - Constants.doubleQualityJump, this.itemsUpdate[10].Quality);
        }

        [TestMethod]
        public void TestNegativeQuality()
        {
            int previousSellIn = this.itemsOriginal[11].SellIn;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[11].SellIn);
            Assert.AreEqual(Constants.minQuality, this.itemsUpdate[11].Quality);
        }

        [TestMethod]
        public void TestConjuredNormal()
        {
            int previousSellIn = this.itemsOriginal[12].SellIn;
            int previousQuality = this.itemsOriginal[12].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[12].SellIn);
            Assert.AreEqual(previousQuality - 2 * Constants.normalQualityJump, this.itemsUpdate[12].Quality);
        }

        [TestMethod]
        public void TestConjuredPastSellIn()
        {
            int previousSellIn = this.itemsOriginal[13].SellIn;
            int previousQuality = this.itemsOriginal[13].Quality;
            Assert.AreEqual(previousSellIn - 1, this.itemsUpdate[13].SellIn);
            Assert.AreEqual(previousQuality - 2 * Constants.doubleQualityJump, this.itemsUpdate[13].Quality);
        }

    }
}
