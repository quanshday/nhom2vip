using System;
using Nhom2vip.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nhom2vip
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new LoginView();
            MainPage = new NavigationPage(new Nhom2vip.View.LoginView());
            //await Navigation.PushAsync(new NavigationPage(new DetailPage()));
            

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
