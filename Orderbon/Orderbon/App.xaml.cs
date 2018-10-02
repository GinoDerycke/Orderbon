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
        public ObservableCollection<OrderWithContact> OrderWithContacts { get; set; }

        public SQLiteAsyncConnection SQLConnection;

        async private Task<bool> LoadContacts()
        {
            await SQLConnection.CreateTableAsync<Contact>();
            List<Contact> Table = await SQLConnection.Table<Contact>().ToListAsync();

            Contacts = new ObservableCollection<Contact>(Table);

            return true;
        }

        async private Task<bool> LoadProducts()
        {
            await SQLConnection.CreateTableAsync<Product>();
            List<Product> Table = await SQLConnection.Table<Product>().ToListAsync();

            Products = new ObservableCollection<Product>(Table);
            
            return true;
        }

        async private Task<bool> LoadOrders()
        {
            await SQLConnection.CreateTableAsync<Order>();
            List<Order> Table = await SQLConnection.Table<Order>().ToListAsync();

            Orders = new ObservableCollection<Order>(Table);

            foreach (Order order in Orders) { order.SetContacts(Contacts); }

            return true;
        }

        private void LoadOrderWithContacts()
        {
            OrderWithContacts = new ObservableCollection<OrderWithContact>();

            /*
             foreach(Order order in Orders)
            {
                OrderWithContact _OrderWithContact = new OrderWithContact();
                _OrderWithContact._Order = order;
                _OrderWithContact._Contact = (Contacts.Single(x => x.Id == order.ContactId) as Contact);
                OrderWithContacts.Add(_OrderWithContact);
            }
            */

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
