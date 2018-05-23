using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Orderbon
{
    public partial class App : Application
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        private void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { ID = 1, Name = "Gino Derycke", Code = "Gino", Group = "None", Phone = "+32 494 440 421" },
                new Contact { ID = 2, Name = "Sharon Missinne", Code = "Sharon", Group = "None", Phone = "+32 494 447 127" }
            };
        }

        private void LoadOrders ()
        {
            Orders = new ObservableCollection<Order>
            {
                new Order { ID = 1, Title = "Bestelling vijzen 1", Date = "01/05/2018", ContactID = 1 },
                new Order { ID = 2, Title = "Geen titel", Date = "02/05/2018", ContactID = 1 },
                new Order { ID = 3, Title = "Kabels", Date = "14/05/2018", ContactID = 2 },
                new Order { ID = 4, Title = "Toebehoren", Date = "17/05/2018", ContactID = 1 },
                new Order { ID = 5, Title = "Bestelling draad", Date = "18/05/2018", ContactID = 2 }
            };

            //return (this.Where(o => o.ID == ID)) as Order;
        }

        public App ()
		{
			InitializeComponent();

            LoadContacts();
             
            LoadOrders();
            
            MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
