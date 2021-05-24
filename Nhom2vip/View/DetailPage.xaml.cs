using System;
using System.Collections.Generic;
using Nhom2vip.Model;
using Xamarin.Forms;

namespace Nhom2vip.View
{
    public partial class DetailPage 
    {
        public DetailPage(ItemModel itemModel)
        {
            InitializeComponent();
            BindingContext = itemModel;
        }

        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
