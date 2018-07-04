﻿using System;
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

        public ContactDetailPage (Contact contact)
		{
            if (contact == null)
                throw new ArgumentNullException();

            BindingContext = contact;

            InitializeComponent ();

            changed = false;
        }

        async private void Save_Activated(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;

            if ((contact.Name == null) || (contact.Name == ""))
            {
                await DisplayAlert("Fout", "Naam mag niet ledig zijn.", "OK");
                return;
            }

            await Navigation.PopAsync();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
        }
    }
}