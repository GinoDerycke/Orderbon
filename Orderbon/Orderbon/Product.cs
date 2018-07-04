using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Orderbon
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private string _code;
        private string _group;
        private string _supplier;
        private string _unit;
        private double _sellingPriceExclVAT;
        private int _stock;
        private int _reserved;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

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

        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged(nameof(Code));
                }
            }

        }

        public string Group
        {
            get { return _group; }
            set
            {
                if (_group != value)
                {
                    _group = value;
                    OnPropertyChanged(nameof(Group));
                }
            }

        }

        public string Supplier
        {
            get { return _supplier; }
            set
            {
                if (_supplier != value)
                {
                    _supplier = value;
                    OnPropertyChanged(nameof(Supplier));
                }
            }

        }

        public string Unit
        {
            get { return _unit; }
            set
            {
                if (_unit != value)
                {
                    _unit = value;
                    OnPropertyChanged(nameof(Unit));
                }
            }

        }

        public double SellingPriceExclVAT
        {
            get { return _sellingPriceExclVAT; }
            set
            {
                if (_sellingPriceExclVAT != value)
                {
                    _sellingPriceExclVAT = value;
                    OnPropertyChanged(nameof(SellingPriceExclVAT));
                }
            }

        }

        public int Stock
        {
            get { return _stock; }
            set
            {
                if (_stock != value)
                {
                    _stock = value;
                    OnPropertyChanged(nameof(Stock));
                }
            }

        }

        public int Reserved
        {
            get { return _reserved; }
            set
            {
                if (_reserved != value)
                {
                    _reserved = value;
                    OnPropertyChanged(nameof(Reserved));
                }
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
