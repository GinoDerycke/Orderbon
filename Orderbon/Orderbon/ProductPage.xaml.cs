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

        public void RefreshListView()
        {
            MyListView.ItemsSource = Items.Where(p => p.Deleted == false);
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
    }
}