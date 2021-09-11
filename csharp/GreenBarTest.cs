using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GreenBarTest
    {
        [Test]
        public void TwiceAsFast()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "test twice as fast", SellIn = 0, Quality = 2 } };
            GreenBar app = new GreenBar(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        [Test]
        public void NoNegativeQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test negative quality", SellIn = 0, Quality = 1 } };
            GreenBar app = new GreenBar(Items);
            app.UpdateQuality();
            Assert.AreNotEqual(-1, Items[0].Quality);
        }
        [Test]
        public void OldCamembertAging()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "test Old Camembert", SellIn = 15, Quality = 2 },
                new Item { Name = "test Old Camembert", SellIn = 8 , Quality = 2 },
                new Item { Name = "test Old Camembert", SellIn = 4, Quality = 2 },
                new Item { Name = "test Old Camembert", SellIn = 0, Quality = 2 } };
            GreenBar app = new GreenBar(Items);
            app.UpdateQuality();
            Assert.AreEqual(3, Items[0].Quality);
            Assert.AreEqual(4, Items[1].Quality);
            Assert.AreEqual(5, Items[2].Quality);
            Assert.AreEqual(0, Items[3].Quality);
        }
        [Test]
        public void MoreThan50Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Old Camembert", SellIn = 5, Quality = 45 } };
            GreenBar app = new GreenBar(Items);
            while (Items[0].SellIn >= 1)
            {
                app.UpdateQuality();
            }  
            Assert.AreEqual(50, Items[0].Quality);
        }
        [Test]
        public void DropTo0AfterConcert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Old Camembert", SellIn = 0, Quality = 45 } };
            GreenBar app = new GreenBar(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
