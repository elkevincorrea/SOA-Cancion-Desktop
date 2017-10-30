using System;
using System.Windows;
using System.Windows.Controls;
using Cancion = ClienteCancion.CancionSW.cancion;

namespace ClienteCancion
{
    /// <summary>
    /// Interaction logic for AgregarWindow.xaml
    /// </summary>
    public partial class AgregarWindow : Window
    {
        private CancionSW.CancionSWClient clienteCancion;

        public AgregarWindow(CancionSW.CancionSWClient clienteCancion)
        {
            this.clienteCancion = clienteCancion;
            InitializeComponent();
        }

        private void AgregarBtn_Click(object sender, RoutedEventArgs e)
        {
            string idStr = IdTxt.Text.Trim();
            int id;
            if (!Int32.TryParse(idStr, out id))
            {
                MessageBox.Show("Ingrese un Id válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string titulo = TituloTxt.Text.Trim();
            if (titulo.Equals(""))
            {
                MessageBox.Show("Ingrese un título válido");
            }
            string nombreArtista = NombreArtistaTxt.Text.Trim();
            if (nombreArtista.Equals(""))
            {
                MessageBox.Show("Ingrese un nombre de artista válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string genero = GeneroTxt.Text.Trim();
            if (genero.Equals(""))
            {
                MessageBox.Show("Ingrese un género válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DateTime? date = FechaLanzamientoPick.SelectedDate;
            if (date == null)
            {
                MessageBox.Show("Ingrese una fecha válida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Cancion cancion = new Cancion() { id = id, genero = genero, titulo = titulo, nombreArtista = nombreArtista, fechaLanzamiento = date.Value, fechaLanzamientoSpecified = true };
            try
            {
                clienteCancion.adicionarCancion(cancion);
                MessageBox.Show("Canción agregada correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                Console.WriteLine(cancion.fechaLanzamiento);
                Close();
            }
            catch
            {
                MessageBox.Show("Ya existe una canción con el id dado :(", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
