using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Orderbon
{
	public partial class OrderPage : ContentPage
	{
        private ObservableCollection<Order> Items { get; set; }

        public OrderPage()
		{
			InitializeComponent();
        }

        public void RefreshListView(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
                MyListView.ItemsSource = Items.Where(o => o.Deleted == false);
            else
                MyListView.ItemsSource = Items.Where(o => (o.Deleted == false) && (o.Title.StartsWith(searchText, true, null)));
        }

        public void SetItems(ObservableCollection<Order> items)
        {
            Items = items;

            MyListView.ItemsSource = Items;
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            var order = e.SelectedItem as Order;
            await Navigation.PushModalAsync(new OrderDetailPage(order, this));
            MyListView.SelectedItem = null;
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }

        async private void Add_Clicked(object sender, EventArgs e)
        {
            var order = new Order();
            order.SetContacts((Application.Current as App).Contacts);

            await Navigation.PushModalAsync(new OrderDetailPage(order, this));
        }
    }
}
