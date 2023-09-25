using System;
using TRAVEL01.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRAVEL01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());

        }

        public void SetMainPageAfterLogin(string userName)
        {
            MainPage = new NavigationPage(new HomePage(userName));
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
