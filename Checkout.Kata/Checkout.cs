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
            throw new NotImplementedException();
        }
    }
}
