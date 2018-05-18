using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Orderbon
{
	public partial class MainPage : ContentPage
	{
        private ObservableCollection<Order> Items { get; set; }

        public MainPage()
		{
			InitializeComponent();

            Items = new ObservableCollection<Order>
            {
                new Order { Title = "Bestelling vijzen", Date = "01/05/2018" },
                new Order { Title = "Geen titel", Date = "02/05/2018" },
                new Order { Title = "Kabels", Date = "14/05/2018" },
                new Order { Title = "Toebehoren", Date = "17/05/2018" },
                new Order { Title = "Bestelling draad", Date = "18/05/2018" }
            };

            MyListView.ItemsSource = Items;
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            var order = e.SelectedItem as Order;
            await Navigation.PushAsync(new OrderDetail(order));
            MyListView.SelectedItem = null;
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

        }
    }
}
