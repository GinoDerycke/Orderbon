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
        }

        public void RefreshListView(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
                MyListView.ItemsSource = Items.Where(p => p.Deleted == false);
            else
                MyListView.ItemsSource = Items.Where(p => (p.Deleted == false) && (p.Name.StartsWith(searchText, true, null)));
        }

        public void SetItems(ObservableCollection<Product> items)
        {
            Items = items;

            RefreshListView();
        }

        async private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var product = e.SelectedItem as Product;
            await Navigation.PushModalAsync(new ProductDetailPage(product, this));
            MyListView.SelectedItem = null;
        }

        async private void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;

            var product = menuItem.CommandParameter as Product;

            var result = await this.DisplayAlert("",  String.Format("Weet je zeker dat je artikel \"{0}\" wilt verwijderen?", product.Name), "Ja", "Nee");
            if (result)
            {
                product.Deleted = true;
                await (Application.Current as App).SQLConnection.UpdateAsync(product);
                RefreshListView();
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            var product = new Product();

            await Navigation.PushModalAsync(new ProductDetailPage(product, this));
        }

        private void MySearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshListView(e.NewTextValue);
        }
    }
}