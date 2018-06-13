using System;
using System.Collections.Generic;
using System.Text;

namespace Orderbon
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Group { get; set; }
        public string Supplier { get; set; }
        public string Unit { get; set; }
        public double SellingPriceExclVAT { get; set; }
        public int Stock { get; set; }
        public int Reserved { get; set; }
    }
}
