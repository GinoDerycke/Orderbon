using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orderbon
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailPage : ContentPage
	{
        private bool Changed;
        private bool New;
        private Product OriProduct;
        private ProductPage _productPage;

        public ProductDetailPage(Product product, ProductPage productPage)
		{
            if (product == null)
                throw new ArgumentNullException();

            BindingContext = product;
            _productPage = productPage;

            InitializeComponent();

            Changed = false;

            if (product.Name == null)
            {
                Title = "Nieuw artikel";
                New = true;
            }
            else
            {
                New = false;
                OriProduct = new Product();
                product.Copy(OriProduct);
            }
                
        }

        async private Task<bool> DoSave(Product product)
        {
            if (New)
            {
                await (Application.Current as App).SQLConnection.InsertAsync(product);
                (Application.Current as App).Products.Add(product);
                _productPage.RefreshListView();
            }
            else
                await (Application.Current as App).SQLConnection.UpdateAsync(product);

            return true;
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            var product = BindingContext as Product;

            if ((product.Name == null) || (product.Name == ""))
            {
                await DisplayAlert("Invoerfout", "Naam mag niet ledig zijn.", "OK");
                return;
            }

            await DoSave(product);

            await Navigation.PopModalAsync();
        }

        async private Task<bool> Check_Changed()
        {
            var product = BindingContext as Product;

            if (Changed)
            {
                var result = await this.DisplayAlert("", "De wijzigingen zijn niet opgeslagen.", "Opslaan", "Niet opslaan");
                if (result)
                {
                    await DoSave(product);
                }
                else
                    if (OriProduct != null) OriProduct.Copy(product);
            }

            return true;
        }

        async private void Cancel_Clicked(object sender, EventArgs e)
        {
            await Check_Changed();

            await Navigation.PopModalAsync();
        }
        
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var entryPrice = this.FindByName<Entry>("entryPrice");

            //if ((sender == entryPrice) && (entryPrice.Text.Contains("€") == false))
            //    entryPrice.Text = e.NewTextValue.ToString() + " €";

            Changed = true;
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                await Check_Changed();
                await Navigation.PopModalAsync();
            });

            return true;
        }
    }
}