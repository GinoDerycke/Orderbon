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
        private ObservableCollection<Contact> Items { get; set; }

        public ContactPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<Contact>
            {
                new Contact { Name = "Gino Derycke", Code = "Gino", Group = "None", Phone = "+32 494 440 421" },
                new Contact { Name = "Sharon Missinne", Code = "Sharon", Group = "None", Phone = "+32 494 447 127" }
            };
        			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
