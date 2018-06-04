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
		public OrderDetail (OrderWithContact orderWithContact)
		{
            if (orderWithContact == null)
                throw new ArgumentNullException();

            BindingContext = orderWithContact;

            InitializeComponent ();
        }

    }
}