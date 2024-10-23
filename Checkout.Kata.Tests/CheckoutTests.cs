using Checkout.Kata;

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
        public void Scan_MultipleItem_ItemsAreScannedCorrectly()
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
    }
}