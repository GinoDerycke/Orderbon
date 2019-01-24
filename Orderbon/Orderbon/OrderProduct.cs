using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Orderbon
{
    public class OrderProduct : INotifyPropertyChanged
    {
        private int _productId;
        private float _quantity;
        private bool _deleted;
        private ObservableCollection<Product> _products;

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged(nameof(ProductId));
                }
            }
        }

        public float Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
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

        [Ignore]
        public Product Product
        {
            get
            {
                if (_products != null)
                {
                    var observable = _products.Where(c => (c.Id == ProductId));
                    if (observable.Count() == 1)
                        return observable.First() as Product;
                    else
                        return null;
                }
                else
                    throw new ArgumentNullException();
            }
            set
            {
                ProductId = Product.Id;
                OnPropertyChanged(nameof(Product));
            }
        }

        public void SetProducts(ObservableCollection<Product> Products)
        {
            _products = Products;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
