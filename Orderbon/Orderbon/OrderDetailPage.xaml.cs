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

        private bool New;
        private bool Changed;
        private OrderPage _orderPage;

        public OrderDetailPage(Order order, OrderPage orderPage)
		{
            if (order == null)
                throw new ArgumentNullException();

            BindingContext = order;
            _orderPage = orderPage;

            InitializeComponent ();

            Changed = false;

            if (order.Title == null)
            {
                Title = "Nieuw order";
                New = true;
            }
            else
            {
                New = false;
                //OriProduct = new Product();
                //product.Copy(OriProduct);
            }
        }

        async private Task<bool> DoSave(Order order)
        {
            if (New)
            {
                await (Application.Current as App).SQLConnection.InsertAsync(order);
                (Application.Current as App).Orders.Add(order);
                _orderPage.RefreshListView();
            }
            else
                await (Application.Current as App).SQLConnection.UpdateAsync(order);

            return true;
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            var order = BindingContext as Order;

            if ((order.Title == null) || (order.Title == ""))
            {
                await DisplayAlert("Invoerfout", "Titel mag niet ledig zijn.", "OK");
                return;
            }

            if (order.ContactId == 0)
            {
                await DisplayAlert("Invoerfout", "Contact mag niet ledig zijn.", "OK");
                return;
            }

            await DoSave(order);

            await Navigation.PopModalAsync();
        }

        async private void Cancel_Clicked(object sender, EventArgs e)
        {
            //await Check_Changed();

            await Navigation.PopModalAsync();
        }

        async private void Contact_Focused(object sender, FocusEventArgs e)
        {
            Entry entry = e.VisualElement as Entry;
            entry.Unfocus();

            ContactPage contactPage = new ContactPage(this);
            contactPage.SetItems((Application.Current as App).Contacts);

            await Navigation.PushModalAsync(contactPage);
        }

        public void RefreshContact()
        {
            Order order = BindingContext as Order;

            this.FindByName<Entry>("ContactEntry").Text = order.Contact.Name;
        }
    }
}