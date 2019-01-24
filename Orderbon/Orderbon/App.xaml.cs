using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        public SQLiteAsyncConnection SQLConnection;

        async private Task<bool> LoadContacts()
        {
            await SQLConnection.CreateTableAsync<Contact>();
            List<Contact> Table = await SQLConnection.Table<Contact>().ToListAsync();

            Contacts = new ObservableCollection<Contact>(Table);

            if (Contacts.Count == 0) //TODO Verwijderen
            {
                Contacts.Add(new Contact { Id = 1, Name = "Gino Derycke" });
                Contacts.Add(new Contact { Id = 2, Name = "Sharon Missinne" });
                Contacts.Add(new Contact { Id = 3, Name = "Mats Derycke" });
                Contacts.Add(new Contact { Id = 4, Name = "Niene Derycke" });
            }

            return true;
        }

        async private Task<bool> LoadProducts()
        {
            await SQLConnection.CreateTableAsync<Product>();
            List<Product> Table = await SQLConnection.Table<Product>().ToListAsync();

            Products = new ObservableCollection<Product>(Table);

            if (Products.Count == 0) //TODO Verwijderen
            {
                Products.Add(new Product { Id = 1, Name = "Lepel", SellingPriceExclVAT = 1, Unit = "Stuks"});
                Products.Add(new Product { Id = 2, Name = "Vork", SellingPriceExclVAT = 10, Unit = "Stuks" });
                Products.Add(new Product { Id = 3, Name = "Mes", SellingPriceExclVAT = 20, Unit = "Stuks" });
                Products.Add(new Product { Id = 4, Name = "Bord", SellingPriceExclVAT = 4, Unit = "Stuks" });
                Products.Add(new Product { Id = 5, Name = "Glas", SellingPriceExclVAT = 5, Unit = "Stuks" });
            }

            return true;
        }

        async private Task<bool> LoadOrders()
        {
            await SQLConnection.CreateTableAsync<Order>();
            List<Order> Table = await SQLConnection.Table<Order>().ToListAsync();

            Orders = new ObservableCollection<Order>(Table);

            if (Orders.Count == 0) //TODO Verwijderen
            {
                Order order = new Order();
                order.SetContacts(Contacts);
                order.Title = "Bestelling 1";
                order.ContactId = 2;
                Orders.Add(order);

                Order order2 = new Order();
                order2.SetContacts(Contacts);
                order2.Title = "Bestelling 2";
                order2.ContactId = 1;
                Orders.Add(order2);

                Order order3 = new Order();
                order3.SetContacts(Contacts);
                order3.Title = "Bestelling 3";
                order3.ContactId = 4;
                Orders.Add(order3);

                Order order4 = new Order();
                order4.SetContacts(Contacts);
                order4.Title = "Bestelling 4";
                order4.ContactId = 3;
                Orders.Add(order4);
            }

            foreach (Order order in Orders) { order.SetContacts(Contacts); }

            return true;
        }

        async public Task<bool> LoadData()
        {
            SQLConnection = DependencyService.Get<ISQLiteDb>().GetConnection();

            var res = (await LoadProducts()) && 
                      (await LoadContacts()) &&
                      (await LoadOrders());

            return res;
        }

        public App ()
		{
			InitializeComponent();
        }

        protected override void OnStart ()
		{
            // Handle when your app starts

            MainPage = new MainPage();
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
