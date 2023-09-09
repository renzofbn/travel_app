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
    public partial class SignUpPage : ContentPage
    {
        IAuth auth;
        public SignUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async  void SingUpNewUser(object sender, EventArgs e)
        {
            string email = EmailInput.Text;
            string password = PasswordInput.Text;
            string passwordConfirm = ConfirmPasswordInput.Text;

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirm))
            {
                ShowError("Cuidado", "Todos los campos son obligatorios");
                return;
            }
            if(password != passwordConfirm)
            {
                ShowError("Upsss", "Las contraseñas no coinciden");
                return;
            }

            string Token = await auth.SignUpWithEmailPassword(email, password);

            if (!string.IsNullOrEmpty(Token))
            {
                ShowError("Bienvenido", "Tu cuenta ha sido creada con éxito");
                await Navigation.PushAsync(new SignInPage());
            }
            else
                ShowError("Error", "Tus credenciales son incorrectas");
        }
        async private void ShowError(string title, string msg)
        {
            await DisplayAlert(title, msg, "OK");
        }
    }
}