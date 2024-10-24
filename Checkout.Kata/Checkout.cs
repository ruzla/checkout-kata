using Checkout.Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (count > 0)
                {
                    total += count * item.unitPrice;
                }
            }

            return total;
        }
    }
}
