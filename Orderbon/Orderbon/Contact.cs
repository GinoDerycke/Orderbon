using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Orderbon
{
    public class Contact : INotifyPropertyChanged
    {

        private string _name;

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
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Group { get; set; }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
