using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace travellApp
{
    [DesignTimeVisible(true)]
    public partial class SignInPage : ContentPage
    {
        IAuth auth;
        public SignInPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            if (auth.IsSignIn())
            {
                Navigation.PopToRootAsync();
                Navigation.PushAsync(new MainPage());
            }
        }
        async void LoginClicked(object sender, EventArgs e)
        {
            string email = EmailInput.Text;
            string password = PasswordInput.Text;
            string emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowError("Cuidado", "El correo y la contraseña con obligatorios");
                return;
            }

            if(!Regex.IsMatch(email, emailPattern))
            {
                ShowError("Upsss", "Parece que tu correo no es valido");
                return;
            }   

            string Token = await auth.LoginWithEmailPassword(email, password);
            if (!string.IsNullOrEmpty(Token))
            {
                // El token es válido, puedes continuar con el flujo de tu aplicación
                await Navigation.PushAsync(new MainPage());
            }
            else
                ShowError("Error", "Tus credenciales son incorrectas");
        }

        async void RegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void LoginGoogleClicked(object sender, EventArgs e)
        {
            ShowError("Upsss", "Esta funcionalidad no está disponible por el momento");
        }
        async private void ShowError(string title, string msg)
        {
            await DisplayAlert(title, msg, "OK");
        }
    }
}
