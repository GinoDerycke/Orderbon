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
        private bool Changed;
        private bool New;
        private Contact OriContact;
        private ContactPage _contactPage;

        public ContactDetailPage(Contact contact, ContactPage contactPage)
        {
            if (contact == null)
                throw new ArgumentNullException();

            BindingContext = contact;
            _contactPage = contactPage;

            InitializeComponent();

            Changed = false;

            if (contact.Name == null)
            {
                Title = "Nieuwe klant";
                New = true;
            }
            else
            {
                New = false;
                OriContact = new Contact();
                contact.Copy(OriContact);
            }
        }

        async private Task<bool> DoSave(Contact contact)
        {
            if (New)
            {
                await (Application.Current as App).SQLConnection.InsertAsync(contact);
                (Application.Current as App).Contacts.Add(contact);
                _contactPage.RefreshListView();
            }
            else
                await (Application.Current as App).SQLConnection.UpdateAsync(contact);

            return true;
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;

            if ((contact.Name == null) || (contact.Name == ""))
            {
                await DisplayAlert("Invoerfout", "Naam mag niet ledig zijn.", "OK");
                return;
            }

            await DoSave(contact);

            await Navigation.PopModalAsync();
        }

        async private Task<bool> Check_Changed()
        {
            var contact = BindingContext as Contact;

            if (Changed)
            {
                var result = await this.DisplayAlert("", "De wijzigingen zijn niet opgeslagen.", "Opslaan", "Niet opslaan");
                if (result)
                {
                    await DoSave(contact);
                }
                else
                    if (OriContact != null) OriContact.Copy(contact);
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
            Changed = true;
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