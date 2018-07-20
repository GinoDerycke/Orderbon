using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orderbon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        private bool FirstTime;

        public MainPage()
        {
            InitializeComponent();
                
            FirstTime = true;
        }

        protected override async void OnAppearing()
        {
            if (FirstTime)
            {
                await (Application.Current as App).LoadData();

                (NavOrderPage.RootPage as OrderPage).SetItems((Application.Current as App).OrderWithContacts);
                (NavCustomerPage.RootPage as ContactPage).SetItems((Application.Current as App).Contacts);
                (NavProductPage.RootPage as ProductPage).SetItems((Application.Current as App).Products);

                FirstTime = false;
            };
           
            base.OnAppearing();
        }
    }
}