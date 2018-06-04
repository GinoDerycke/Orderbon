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
        private ObservableCollection<OrderWithContact> Items { get; set; }

        public OrderPage()
		{
			InitializeComponent();

            Items = (Application.Current as App).OrderWithContacts;

            MyListView.ItemsSource = Items;
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            var orderWithContact = e.SelectedItem as OrderWithContact;
            await Navigation.PushAsync(new OrderDetailPage(orderWithContact));
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
