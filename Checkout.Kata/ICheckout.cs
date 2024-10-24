﻿using Checkout.Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Kata
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice(List<Item> priceList);
    }
}
