using System;
using System.Collections.Generic;
using System.Text;

namespace Orderbon
{
    public class Order
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public Contact Contact { get; set; }
    }
}
