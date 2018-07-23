using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Orderbon
{
    public class Contact : INotifyPropertyChanged
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
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Group { get; set; }

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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Copy(Contact DestContact)
        {
            DestContact.Name = Name;
            DestContact.Code = Code;
            DestContact.Phone = Phone;
            DestContact.Group = Group;
            DestContact.Deleted = Deleted;
        }
    }
}
