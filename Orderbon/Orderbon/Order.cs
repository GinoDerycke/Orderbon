using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace Orderbon
{
    public class Order : INotifyPropertyChanged
    {
        private string _title;
        private string _date;
        private bool _deleted = false;
        private int _contactId;
        private ObservableCollection<Contact> _contacts;

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
            get { return _contactId; }
            set
            {
                if (_contactId != value)
                {
                    _contactId = value;
                    OnPropertyChanged(nameof(ContactId));
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
        public Contact Contact
        {
            get
            {
                if (_contacts != null)
                    return _contacts.Where(c => (c.Id == ContactId)) as Contact;
                else 
                    throw new ArgumentNullException();
            }
            set { ContactId = Contact.Id; }
        }

        public void SetContacts(ObservableCollection<Contact> Contacts)
        {
            _contacts = Contacts;
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
