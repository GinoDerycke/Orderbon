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

            Items = (Application.Current as App).Orders;

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

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}
