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
        private string _code;
        private string _group;
        private string _supplier;
        private string _unit;
        private double _sellingPriceExclVAT;
        private int _stock;
        private int _reserved;

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

        [MaxLength(255)]
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

        [MaxLength(255)]
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

        [MaxLength(255)]
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

        public Product()
        {
            _name = "";
            _code = "";
            _group = "";
            _supplier = "";
            _unit = "";
            _sellingPriceExclVAT = 0.0;
            _stock = 0;
            _reserved = 0;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
