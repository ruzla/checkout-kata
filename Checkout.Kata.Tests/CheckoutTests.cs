using Checkout.Kata.Models;

namespace Checkout.Kata.Tests
{
    public class CheckoutTests
    {
        private Checkout _checkout;
        private List<Item> _priceList;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
            _priceList = new List<Item>
                {
                    new Item { sku = "A", unitPrice = 50, specialQuantity = 3, specialDiscount = 130 },
                    new Item { sku = "B", unitPrice = 30, specialQuantity = 2, specialDiscount = 45 },
                    new Item { sku = "C", unitPrice = 20 },
                    new Item { sku = "D", unitPrice = 15 }
                };
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
        public void GetTotal_ScannedNoOffersItems_TotalIsCalculatedCorrectly()
        {
            //arrange
            var expectedTotal = 55;

            //act
            _checkout.Scan("C");
            _checkout.Scan("D");
            _checkout.Scan("C");
            var total = _checkout.GetTotalPrice(_priceList);

            //assert
            Assert.That(total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void GetTotal_ScannedWithOffersItems_TotalIsCalculatedCorrectly()
        {
            //arrange
            var expectedTotal = 175;

            //act
            _checkout.Scan("B");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            var total = _checkout.GetTotalPrice(_priceList);

            //assert
            Assert.That(total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void GetTotal_ScannedMixedOffersItems_TotalIsCalculatedCorrectly()
        {
            //arrange
            var expectedTotal = 230;

            //act
            _checkout.Scan("B");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");
            _checkout.Scan("C");
            var total = _checkout.GetTotalPrice(_priceList);

            //assert
            Assert.That(total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void GetTotal_ScannedMixedSpecialOfferItems_TotalIsCalculatedCorrectly()
        {
            //arrange
            var expectedTotal = 325;

            //act
            _checkout.Scan("B");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("B");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");
            _checkout.Scan("C");
            var total = _checkout.GetTotalPrice(_priceList);

            //assert
            Assert.That(total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void GetTotal_ScannedDoubleSpecialOfferItems_TotalIsCalculatedCorrectly()
        {
            //arrange
            var expectedTotal = 405;

            //act
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("B");
            _checkout.Scan("B");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");
            _checkout.Scan("C");
            var total = _checkout.GetTotalPrice(_priceList);

            //assert
            Assert.That(total, Is.EqualTo(expectedTotal));
        }
    }
}