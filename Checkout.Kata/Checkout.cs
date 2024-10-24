using Checkout.Kata.Models;

namespace Checkout.Kata
{
    public class Checkout : ICheckout
    {
        public List<string> items = new List<string>();

        public void Scan(string item)
        {
            items.Add(item);
        }

        public int GetTotalPrice(List<Item> priceList)
        {
            int total = 0;

            foreach (var item in priceList)
            {
                int count = items.Count(i => i == item.sku);

                if (item.specialQuantity > 0 && count >= item.specialQuantity)
                {
                    total += CalculateDiscountedPrice(item, count);
                }
                else
                {
                    total += count * item.unitPrice;
                }
            }

            return total;
        }

        private int CalculateDiscountedPrice(Item item, int count)
        {
            int discountedItems = count / item.specialQuantity;
            int remainder = count % item.specialQuantity;
            return discountedItems * item.specialDiscount + remainder * item.unitPrice;
        }
    }
}
