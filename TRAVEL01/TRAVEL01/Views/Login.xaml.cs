// Login.xaml.cs
using SQLite;
using System;
using System.IO;
using TRAVEL01.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRAVEL01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        async void Handle_Clicked_1(object sender, System.EventArgs e)
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u => u.Email.Equals(EntryUserEmail.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if (myquery != null)
            {
                // Iniciar sesión correctamente y establecer la página principal en HomePage
                ((App)Application.Current).SetMainPageAfterLogin(myquery.UserName);
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Travel:", "Correo u contraseña incorrectos", "Continuar", "Cancelar");
                    if (result)
                        EntryPassword.Text = string.Empty; // Limpiar el campo de contraseña en caso de error
                });
            }
        }
    }
}
