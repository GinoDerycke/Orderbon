using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Orderbon
{
    public class Order : INotifyPropertyChanged
    {
        private string _title;
        private string _date;
        private bool _deleted = false;
        private Contact _contact;

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }

        }

        [MaxLength(255)]
        public string Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }

        }

        public int ContactId
        {
            get
            {
                ...
            }
            set
            {
                ...
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
        public Contact Contact
        {
            get { return _contact; }
            set
            {
                ...
            }
        }
            

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
