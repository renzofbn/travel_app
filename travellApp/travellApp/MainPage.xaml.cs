using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travellApp
{
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        IAuth auth;
        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            if (!auth.IsSignIn())
            {
                Navigation.PopToRootAsync();
                Navigation.PushAsync(new SignInPage());
            }
        }
    
        async void LogOutClicked(object sender, EventArgs e)
        {
           auth.SignOut();
           await Navigation.PopToRootAsync();
           await Navigation.PushAsync(new SignInPage());
        }
    }
}