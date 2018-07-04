using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orderbon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ObservableCollection<Contact> Items { get; set; }

        public ContactPage()
        {
            InitializeComponent();

            Items = (Application.Current as App).Contacts;

            MyListView.ItemsSource = Items;
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new ContactDetailPage(contact));
            MyListView.SelectedItem = null;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }

        async private void Add_Clicked(object sender, EventArgs e)
        {
            var contact = new Contact();

            await Navigation.PushAsync(new ContactDetailPage(contact));

            if (contact.Name != "")
                Items.Add(contact);
        }
    }
}
