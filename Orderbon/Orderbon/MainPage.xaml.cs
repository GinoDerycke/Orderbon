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

                this.Children.Add(new NavigationPage(new OrderPage()) { Title = "Orders" });
                this.Children.Add(new NavigationPage(new ContactPage()) { Title = "Klanten" });
                this.Children.Add(new NavigationPage(new ProductPage()) { Title = "Artikelen" });

                FirstTime = false;
            };
           
            base.OnAppearing();
        }
    }
}