using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Kata
{
    public class Checkout
    {
        public List<string> items = new List<string>();

        public void Scan(string item)
        {
            items.Add(item);
        }
    }
}
