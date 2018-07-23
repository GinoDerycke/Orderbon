using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Orderbon
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private bool _deleted = false;

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }

        }

        [MaxLength(255)]
        public string Code { get; set; }

        [MaxLength(255)]
        public string Group { get; set; }

        [MaxLength(255)]
        public string Supplier { get; set; }

        [MaxLength(255)]
        public string Unit { get; set; }

        public double SellingPriceExclVAT { get; set; }

        public int Stock { get; set; }

        public int Reserved { get; set; }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Deleted
        {
            get { return _deleted; }
            set
            {
                if (_deleted != value)
                {
                    _deleted = value;
                    OnPropertyChanged(nameof(Deleted));
                }
            }

        }

        public void Copy(Product DestProduct)
        {
            DestProduct.Name = Name;
            DestProduct.Code = Code;
            DestProduct.Group = Group;
            DestProduct.Supplier = Supplier;
            DestProduct.Unit = Unit;
            DestProduct.SellingPriceExclVAT = SellingPriceExclVAT;
            DestProduct.Stock = Stock;
            DestProduct.Reserved = Reserved;
            DestProduct.Deleted = Deleted;
        }
    }
}
