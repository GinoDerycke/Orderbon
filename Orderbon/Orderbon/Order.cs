using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Orderbon
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int ContactId { get; set; }
    }

}
