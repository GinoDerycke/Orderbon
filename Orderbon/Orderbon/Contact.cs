using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Orderbon
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Group { get; set; }
        /*
         public Image Icon
        {
            get
            {
                
                Image temp = new Image();
                //temp.Width = "50";
                //temp.Height = "50";
                //temp.BackgroundColor = "yellow";


                return temp;
            }

        }
        */
    }
}
