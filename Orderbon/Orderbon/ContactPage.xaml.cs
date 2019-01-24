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
        private OrderDetailPage _OrderDetailPage;

        public ObservableCollection<Contact> Items { get; set; }
               
        public ContactPage(OrderDetailPage OrderDetailPage = null)
        {
            InitializeComponent();

            _OrderDetailPage = OrderDetailPage;

            if (_OrderDetailPage == null)
            {
                this.FindByName<StackLayout>("TopBar").IsVisible = false;
            }

        }

        public void RefreshListView(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
                MyListView.ItemsSource = Items.Where(c => c.Deleted == false);
            else
                MyListView.ItemsSource = Items.Where(c => (c.Deleted == false) && (c.Name.StartsWith(searchText, true, null)));
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

            if (_OrderDetailPage == null)
            {
                await Navigation.PushModalAsync(new ContactDetailPage(contact, this));
            }
            else
            {
                Order order = _OrderDetailPage.BindingContext as Order;
                order.ContactId = contact.Id;
                _OrderDetailPage.RefreshContact();
                await Navigation.PopModalAsync();
            }

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

        private void MySearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshListView(e.NewTextValue);
        }

        async private void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
