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
    public partial class ContactDetailPage : ContentPage
    {
        private bool changed;

        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException();

            BindingContext = contact;

            InitializeComponent();

            changed = false;

            if (contact.Name == null)
                Title = "Nieuwe klant";
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;

            if ((contact.Name == null) || (contact.Name == ""))
            {
                await DisplayAlert("Invoerfout", "Naam mag niet ledig zijn.", "OK");
                return;
            }

            await Navigation.PopModalAsync();

        }

        async private Task<bool> Check_Changed()
        {
            if (changed)
            {
                var result = await this.DisplayAlert("", "De wijzigingen zijn niet opgeslagen.", "Opslaan", "Niet opslaan");
                if (result) await this.Navigation.PopModalAsync();
            }

            return true;
        }

        async private void Cancel_Clicked(object sender, EventArgs e)
        {
            await Check_Changed();

            await Navigation.PopModalAsync();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                await Check_Changed();
                await Navigation.PopModalAsync();
             });

            return true;
        }
    }
}