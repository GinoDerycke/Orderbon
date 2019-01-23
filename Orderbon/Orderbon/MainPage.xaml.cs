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

            //OrderPage orderPage = new OrderPage();

            //ContactPage contactPage = new ContactPage();

            //ProductPage productPage = new ProductPage();

            //NavigationPage navOrderPage = new NavigationPage(orderPage);
            //navOrderPage.Title = "Orders";
            //navOrderPage.Icon = "baseline_list_black_18.png";


            //NavigationPage navContactPage = new NavigationPage(contactPage);
            //navContactPage.Title = "Klanten";
            //navContactPage.Icon = "baseline_person_black_18.png";

            //NavigationPage navProductPage = new NavigationPage(productPage);
            //navProductPage.Title = "Artikelen";
            //navProductPage.Icon = "baseline_storage_black_18.png";

            //TabbedPage tabPage = this.FindByName<TabbedPage>("TabPage");

            //tabPage.Children.Add(navOrderPage);
            //tabPage.Children.Add(navContactPage);
            //tabPage.Children.Add(navProductPage);

            //FirstTime = true;
        }

        protected override async void OnAppearing()
        {
            if (FirstTime)
            {
                await (Application.Current as App).LoadData();

                TabbedPage tabPage = this.FindByName<TabbedPage>("TabPage");

                OrderPage orderPage = (tabPage.Children[0] as NavigationPage).RootPage as OrderPage;
                ContactPage contactPage = (tabPage.Children[1] as NavigationPage).RootPage as ContactPage;
                ProductPage productPage = (tabPage.Children[2] as NavigationPage).RootPage as ProductPage;

                orderPage.SetItems((Application.Current as App).Orders);
                contactPage.SetItems((Application.Current as App).Contacts);
                productPage.SetItems((Application.Current as App).Products);

                //(NavOrderPage.RootPage as OrderPage).SetItems((Application.Current as App).Orders);
                //(NavCustomerPage.RootPage as ContactPage).SetItems((Application.Current as App).Contacts);
                //(NavProductPage.RootPage as ProductPage).SetItems((Application.Current as App).Products);

                FirstTime = false;
            };
           
            base.OnAppearing();
        }
    }
}