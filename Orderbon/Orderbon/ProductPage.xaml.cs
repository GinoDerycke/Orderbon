using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orderbon
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductPage : ContentPage
	{
        public ObservableCollection<Product> Items { get; set; }

        public ProductPage ()
		{
			InitializeComponent ();

            Items = (Application.Current as App).Products;

            MyListView.ItemsSource = Items;
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var product = e.SelectedItem as Product;
            await Navigation.PushAsync(new ProductDetailPage(product));
            MyListView.SelectedItem = null;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}