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
        }

        public void RefreshListView()
        {
            MyListView.ItemsSource = Items.Where(c => c.Deleted == false);
        }

        public void SetItems(ObservableCollection<Contact> items)
        {
            Items = items;

            RefreshListView();
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;
            await Navigation.PushModalAsync(new ContactDetailPage(contact, this));
            MyListView.SelectedItem = null;
        }

        async private void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;

            var contact = menuItem.CommandParameter as Contact;

            var result = await this.DisplayAlert("", String.Format("Weet je zeker dat je klant \"{0}\" wilt verwijderen?", contact.Name), "Ja", "Nee");
            if (result)
            { 
                contact.Deleted = true;
                await (Application.Current as App).SQLConnection.UpdateAsync(contact);
                RefreshListView();
            }
        }

        async private void Add_Clicked(object sender, EventArgs e)
        {
            var contact = new Contact();

            await Navigation.PushModalAsync(new ContactDetailPage(contact, this));
        }
    }
}
