using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Orderbon

    public partial class App : Application
	{

        public ObservableCollection<Contact> Contacts { get; set; }
{
        public App ()
		{
			InitializeComponent();

            Contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "Gino Derycke", Code = "Gino", Group = "None", Phone = "+32 494 440 421" },
                new Contact { Name = "Sharon Missinne", Code = "Sharon", Group = "None", Phone = "+32 494 447 127" }
            };

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
