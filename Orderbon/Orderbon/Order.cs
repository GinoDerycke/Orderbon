using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Orderbon
{
    public class Order
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int ContactID { get; set; }
    }

}
