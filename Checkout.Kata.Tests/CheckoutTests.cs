using Checkout.Kata;
using Checkout.Kata.Models;

namespace Checkout.Kata.Tests
{
    public class CheckoutTests
    {
        private Checkout _checkout;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void Scan_SingleItem_ItemIsScannedCorrectly()
        {
            //arrange
            var expectedScannedItems = new List<string> { "A" };

            //act
            _checkout.Scan("A");
            var scannedItems = _checkout.items;

            //assert
            Assert.That(scannedItems, Is.EqualTo(expectedScannedItems));
        }


        [Test]
        public void Scan_MultipleItems_ItemsAreScannedCorrectly()
        {
            //arrange
            var expectedScannedItems = new List<string> { "A", "B", "C" };

            //act
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("C");
            var scannedItems = _checkout.items;

            //assert
            Assert.That(scannedItems, Is.EqualTo(expectedScannedItems));
        }

        [Test]
        public void GetTotalOfNoOffersScannedItems_TotalIsCalculatedCorrectly()
        {
            //arrange
            var priceList = new List<Item>
            {
                new Item { sku = "C", unitPrice = 20 },
                new Item { sku = "D", unitPrice = 15 }
            };
            var expectedTotal = 55;

            //act
            _checkout.Scan("C");
            _checkout.Scan("D");
            _checkout.Scan("C");
            var total = _checkout.GetTotalPrice(priceList);

            //assert
            Assert.That(total, Is.EqualTo(expectedTotal));
        }
    }
}