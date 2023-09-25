using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAVEL01.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRAVEL01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntryUserName.Text) ||
                string.IsNullOrWhiteSpace(EntryUserPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(EntryUserEmail.Text) ||
                string.IsNullOrWhiteSpace(EntryUserLastName.Text) ||
                string.IsNullOrWhiteSpace(EntryUserPassword.Text) ||
                DatePickerUserDOB.Date == DateTime.MinValue) // Verificamos si la fecha de nacimiento es válida
            {
                DisplayAlert("Travel:", "Tienes campos vacíos", "Ok");
                return;
            }

            // Calcular la edad a partir de la fecha de nacimiento
            var today = DateTime.Today;
            var age = today.Year - DatePickerUserDOB.Date.Year;
            if (DatePickerUserDOB.Date > today.AddYears(-age))
                age--;

            // Verificar si el usuario es menor de edad (por ejemplo, menor de 18 años)
            if (age < 18)
            {
                DisplayAlert("Travel:", "Debes ser mayor de edad para registrarte", "Ok");
                return;
            }

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = EntryUserName.Text,
                PhoneNumber = EntryUserPhoneNumber.Text,
                Email = EntryUserEmail.Text,
                Password = EntryUserPassword.Text,
                LastName = EntryUserLastName.Text,
                IDNumber = EntryUserIDNumber.Text,
                DateOfBirth = DatePickerUserDOB.Date // Asignamos la fecha de nacimiento desde el DatePicker
            };

            db.Insert(item);

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Travel:", "Registro exitoso", "Continuar", "Cancelar");
                if (result)
                    await Navigation.PushAsync(new Login());
            });
        }

    }
}
