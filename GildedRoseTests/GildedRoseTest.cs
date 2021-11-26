using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void GivenItemWithQualityOfZero_WhenUpdatingQuality_ThenQualityIsNeverLessThanZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.True(Items[0].Quality >= 0);
        }

        [Fact]
        public void GivenItem_WhenSellInGreaterThanZero_ThenQualityReducesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(49, Items[0].Quality);
        }

        [Fact]
        public void GivenItem_WhenSellInEqualsZero_ThenQualityReducesByTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(48, Items[0].Quality);
        }

        [Fact]
        public void GivenItemWithQualityOfFiftyNamedAgedBrie_WhenUpdatingQuality_ThenQualityIsNeverGreaterThanFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.True(Items[0].Quality <= 50);
        }

        [Fact]
        public void GivenItemNamedAgedBrie_WhenUpdatingQuality_ThenQualityIncreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void GivenItemNamedSulfuras_WhenUpdatingQuality_ThenQualityDoesNotChange()
        {
            var originalQuality = 70;
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = originalQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(originalQuality, Items[0].Quality);
        }

        [Fact]
        public void GivenItemNamedBackstagePasses_WhenThereAreMoreThanTenDaysLeft_ThenQualityIncreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void GivenItemNamedBackstagePasses_WhenThereAreTenDaysLeft_ThenQualityIncreasesByTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void GivenItemNamedBackstagePasses_WhenThereAreFiveDaysLeft_ThenQualityIncreasesByThree()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void GivenItemNamedBackstagePasses_WhenThereAreZeroDaysLeft_ThenQualityIsZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
    }
}
