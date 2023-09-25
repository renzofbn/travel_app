using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRAVEL01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private string _UserName;

        public HomePage(string UserName)
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            _UserName = UserName;
            UserNameLabel.Text = "Bienvenido, " + UserName;
        }

        private async void MostrarInformacionTapped(object sender, EventArgs e)
        {
            var nombreDestino = "Huacachina - Ica"; // Reemplaza con el nombre del destino correspondiente a esta imagen

            // Muestra una ventana emergente con información del destino
            await DisplayAlert("Información del Destino", $"La Huacachina es un pequeño oasis en el desierto de Sechura, Perú, " +
                $"conocido por su laguna y las emocionantes actividades de sandboarding en las dunas circundantes. Es un destino turístico popular en el sur de Perú. {nombreDestino}", "Cerrar");
        }

        private async void ComprarTapped(object sender, EventArgs e)
        {
            // Aquí puedes redirigir a la página "Viaje1.xaml" o realizar cualquier otra acción que desees al hacer clic en "Comprar"
            await Navigation.PushAsync(new Viaje1()); // Asumiendo que "Viaje1Page" es el nombre de tu archivo XAML para la página de compra
        }


        private async void MostrarInformacionTapped01(object sender, EventArgs e)
        {
            var nombreDestino = "Laguna 69 - Ancash"; // Reemplaza con el nombre del destino correspondiente a esta imagen

            // Muestra una ventana emergente con información del destino
            await DisplayAlert("Información del Destino", $"La Laguna 69 es uno de los destinos naturales más impresionantes de Perú y una joya de la región de Ancash. Su belleza natural y su ubicación en medio de las imponentes montañas de los Andes hacen que sea un lugar muy popular para los amantes de la naturaleza y los entusiastas del senderismo. {nombreDestino}", "Cerrar");
        }

        private async void MostrarInformacionTapped02(object sender, EventArgs e)
        {
            var nombreDestino = "Pacaya Samiria - Amazonas"; // Reemplaza con el nombre del destino correspondiente a esta imagen

            // Muestra una ventana emergente con información del destino
            await DisplayAlert("Información del Destino", $"El Parque Nacional Pacaya Samiria se encuentra en la región de Amazonas, Perú. Es la reserva de agua dulce más grande del mundo, con una biodiversidad excepcional que incluye jaguares, delfines rosados y una variedad de aves exóticas. Ofrece oportunidades únicas para la observación de la vida silvestre y el ecoturismo en la selva amazónica. {nombreDestino}", "Cerrar");
        }

        private async void MostrarInformacionTapped03(object sender, EventArgs e)
        {
            var nombreDestino = "Machu Picchu - Cusco"; // Reemplaza con el nombre del destino correspondiente a esta imagen

            // Muestra una ventana emergente con información del destino
            await DisplayAlert("Información del Destino", $"Machu Picchu, ubicada en la región de Cusco, Perú, es uno de los sitios arqueológicos más icónicos del mundo. Esta antigua ciudad inca, construida en el siglo XV, se encuentra en lo alto de los Andes y ofrece impresionantes vistas de montañas y valles. Es famosa por su arquitectura impresionante y su importancia cultural e histórica, siendo declarada Patrimonio de la Humanidad por la UNESCO. {nombreDestino}", "Cerrar");
        }

        private async void MostrarInformacionTapped04(object sender, EventArgs e)
        {
            var nombreDestino = "Montaña de 7 colores - Cusco"; // Reemplaza con el nombre del destino correspondiente a esta imagen

            // Muestra una ventana emergente con información del destino
            await DisplayAlert("Información del Destino", $"La Montaña de 7 Colores, también conocida como Vinicunca o Montaña Arcoíris, se encuentra en la región de Cusco, Perú. Esta montaña es famosa por sus estratos de colores vibrantes que se formaron debido a la mineralización y erosión de sus capas geológicas. Es un destino de trekking popular y ofrece vistas panorámicas impresionantes de la región andina. La caminata hasta la Montaña de 7 Colores es un desafío moderado y proporciona una experiencia natural única en los Andes peruanos. {nombreDestino}", "Cerrar");
        }

        private async void MostrarInformacionTapped05(object sender, EventArgs e)
        {
            var nombreDestino = "Mancora - Piura"; // Reemplaza con el nombre del destino correspondiente a esta imagen

            // Muestra una ventana emergente con información del destino
            await DisplayAlert("Información del Destino", $"Máncora es una conocida localidad costera ubicada en la región de Piura, en el norte de Perú. Es famosa por sus hermosas playas de arena blanca, su clima cálido y su ambiente relajado. Máncora es un destino popular para los amantes del surf debido a sus olas consistentes, y también ofrece una amplia gama de opciones de alojamiento, restaurantes y vida nocturna. Es un destino turístico muy visitado tanto por los peruanos como por los turistas internacionales que buscan disfrutar del sol y el mar en la costa norte de Perú. {nombreDestino}", "Cerrar");
        }

        private async void Handle_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login());
        }

        private async void IrAHomePageTapped(object sender, EventArgs e)
        {
            // Utiliza la navegación para ir a la página "HomePage.xaml"
            await Navigation.PopToRootAsync(); // Esto asume que HomePage.xaml es la página raíz de tu aplicación
        }

        private async void VerVentas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Boleto());
        }

    }
}
