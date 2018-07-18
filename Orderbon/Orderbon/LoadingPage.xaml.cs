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
	public partial class LoadingPage : ContentPage
	{
		public LoadingPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            (Application.Current as App).SQLConnection = DependencyService.Get<ISQLiteDb>().GetConnection();
            var connection = (Application.Current as App).SQLConnection;

            await connection.DropTableAsync<Product>(); //Verwijderen
            await connection.CreateTableAsync<Product>();

            (Application.Current as App).tableProducts = await connection.Table<Product>().ToListAsync();
            var table = (Application.Current as App).tableProducts;

            (Application.Current as App).Products = new ObservableCollection<Product>(table);
            var products = (Application.Current as App).Products;

            if (products.Count == 0)
            {
                var product = new Product
                {
                    Name = "tegenmoer M12",
                    Code = "+6",
                    Group = "",
                    Supplier = "",
                    SellingPriceExclVAT = 0.14,
                    Unit = "stuks",
                    Stock = 0,
                    Reserved = 0
                };

                products.Add(product);
                await connection.InsertAsync(product);
            }

            label.Text = "Loaded";

            base.OnAppearing();

            await Navigation.PushModalAsync(new MainPage());
        }


    }
}