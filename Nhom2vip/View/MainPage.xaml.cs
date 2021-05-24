using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nhom2vip.Model;
using Nhom2vip.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nhom2vip.View
{
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        MainPageVM MainPageVM;
        public MainPage()
        {
            MainPageVM = new MainPageVM(Navigation);
            InitializeComponent();
            BindingContext = MainPageVM;
        }

        //private void btnCourseList_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new DetailPage());
        //}
    }
}
