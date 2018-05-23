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
	public partial class OrderDetail : ContentPage
	{
		public OrderDetail (Order order)
		{
            if (order == null)
                throw new ArgumentNullException();

            BindingContext = order;

            InitializeComponent ();

            DisplayAlert("Test", "Create OrderDetail", "OK");
        }
	}
}