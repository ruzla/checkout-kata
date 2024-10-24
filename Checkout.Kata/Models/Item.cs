using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Kata.Models
{
    public class Item
    {
        public string sku { get; set; }
        public int unitPrice { get; set; }
        public int specialQuantity { get; set; } = 0;
        public int specialDiscount { get; set; } = 0;
    }
}
