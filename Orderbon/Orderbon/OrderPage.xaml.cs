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
        }

        public void SetItems(ObservableCollection<OrderWithContact> items)
        {
            Items = items;

            MyListView.ItemsSource = Items;
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            var orderWithContact = e.SelectedItem as OrderWithContact;
            await Navigation.PushAsync(new OrderDetailPage(orderWithContact, this));
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
            var orderWithContact = new OrderWithContact();

            await Navigation.PushModalAsync(new OrderDetailPage(orderWithContact, this));
        }
    }
}
