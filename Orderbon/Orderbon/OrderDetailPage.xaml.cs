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
	public partial class OrderDetailPage : ContentPage
	{
        public OrderDetailPage(OrderWithContact orderWithContact, OrderPage orderPage)
		{
            if (orderWithContact == null)
                throw new ArgumentNullException();

            BindingContext = orderWithContact;

            InitializeComponent ();
        }


        async private void Save_Clicked(object sender, EventArgs e)
        {
            /*
             * var product = BindingContext as Product;

            if ((product.Name == null) || (product.Name == ""))
            {
                await DisplayAlert("Invoerfout", "Naam mag niet ledig zijn.", "OK");
                return;
            }

            await DoSave(product);
            */

            await Navigation.PopModalAsync();
        }

        async private void Cancel_Clicked(object sender, EventArgs e)
        {
            //await Check_Changed();

            await Navigation.PopModalAsync();
        }

    }
}