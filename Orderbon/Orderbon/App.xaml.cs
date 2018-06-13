using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Orderbon
{
    public partial class App : Application
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<OrderWithContact> OrderWithContacts { get; set; }

        private void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { Id = 1, Name = "Gino Derycke", Code = "Gino", Group = "None", Phone = "+32 494 440 421" },
                new Contact { Id = 2, Name = "Sharon Missinne", Code = "Sharon", Group = "None", Phone = "+32 494 447 127" }
            };
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Id = 1,
                    Name = "tegenmoer M12",
                    Code = "+6",
                    Group = "",
                    Supplier = "",
                    SellingPriceExclVAT = 0.14,
                    Unit = "stuks",
                    Stock = 0,
                    Reserved = 0 },
                 new Product { Id = 2,
                    Name = "plc  220v rel  output",
                    Code = "6ES7-212-1BB23-0XB0",
                    Group = "",
                    Supplier = "Siemens",
                    SellingPriceExclVAT = 341.55,
                    Unit = "stuks",
                    Stock = 0,
                    Reserved = 0 }
            };
        }

        private void LoadOrders()
        {
            Orders = new ObservableCollection<Order>
            {
                new Order { Id = 1, Title = "Bestelling vijzen 1", Date = "01/05/2018", ContactId = 1 },
                new Order { Id = 2, Title = "Geen titel", Date = "02/05/2018", ContactId = 1 },
                new Order { Id = 3, Title = "Kabels", Date = "14/05/2018", ContactId = 2 },
                new Order { Id = 4, Title = "Toebehoren", Date = "17/05/2018", ContactId = 1 },
                new Order { Id = 5, Title = "Bestelling draad", Date = "18/05/2018", ContactId = 2 }
            };

            //return (this.Where(o => o.ID == ID)) as Order;
        }

        private void LoadOrderWithContacts()
        {
            OrderWithContacts = new ObservableCollection<OrderWithContact>();

            foreach(Order order in Orders)
            {
                OrderWithContact _OrderWithContact = new OrderWithContact();
                _OrderWithContact._Order = order;
                _OrderWithContact._Contact = (Contacts.Single(x => x.Id == order.ContactId) as Contact);
                OrderWithContacts.Add(_OrderWithContact);
            }

        }

        public App ()
		{
			InitializeComponent();

            LoadContacts();
            LoadProducts(); 
            LoadOrders();
            LoadOrderWithContacts();

            MainPage = new MainPage();
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
