using System;
using System.IO;
using TRAVEL01.Tables;
using Xamarin.Forms;
using SQLite;

namespace TRAVEL01.Views
{
    public partial class Viaje1 : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        public Viaje1()
        {
            InitializeComponent();

            // Inicializar la conexión a la base de datos SQLite
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "travel01.db");
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<RegUserTable>();
        }

        private async void GuardarClicked(object sender, EventArgs e)
        {
            try
            {
                // Validar la entrada de datos (por ejemplo, asegurarse de que los campos no estén vacíos)

                int adultos = Convert.ToInt32(AdultosEntry.Text);
                int ninos = Convert.ToInt32(NinosEntry.Text);

                // Obtener la fecha seleccionada del Picker
                string fechaSeleccionada = FechaPicker.SelectedItem.ToString();
                DateTime fecha;

                // Convertir la fecha seleccionada en una fecha real
                switch (fechaSeleccionada)
                {
                    case "LUNES 21":
                        fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 21);
                        break;
                    case "MARTES 22":
                        fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 22);
                        break;
                    case "MIÉRCOLES 23":
                        fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 23);
                        break;
                    default:
                        fecha = DateTime.Now; // Valor por defecto en caso de error
                        break;
                }

                // Crear un nuevo registro
                var regUser = new RegUserTable
                {
                    UserId = Guid.NewGuid(),
                    // Puedes asignar otros valores a las propiedades de RegUserTable según tu lógica
                    DateOfBirth = fecha // Asignar la fecha calculada al registro
                };

                // Insertar el registro en la base de datos SQLite
                await _connection.InsertAsync(regUser);

                DatosVentas.compras.Add(new Compra { CantidadAdultos = int.Parse(AdultosEntry.Text), CantidadNinos = int.Parse(NinosEntry.Text), Fecha = fechaSeleccionada });

                // Mostrar un cuadro emergente de "Compra exitosa"
                await DisplayAlert("Compra Exitosa", "¡Tu compra ha sido exitosa!", "Aceptar");

                // Restablecer los campos de entrada
                AdultosEntry.Text = "";
                NinosEntry.Text = "";
                FechaPicker.SelectedItem = null; // Reiniciar el Picker
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error al procesar la compra.", "Aceptar");
            }
        }


        private async void IrAHomePageTapped(object sender, EventArgs e)
        {
            // Utiliza la navegación para ir a la página "HomePage.xaml"
            await Navigation.PopToRootAsync(); // Esto asume que HomePage.xaml es la página raíz de tu aplicación
        }
    }
}
