using System;
using System.Windows;
using Cancion = ClienteCancion.CancionSW.cancion;

namespace ClienteCancion
{
    /// <summary>
    /// Interaction logic for ActualizarWindow.xaml
    /// </summary>
    public partial class ActualizarWindow : Window
    {
        private CancionSW.CancionSWClient clienteCancion;
        private ViewModelCancion viewModel;

        public ActualizarWindow(CancionSW.CancionSWClient clienteCancion)
        {
            this.clienteCancion = clienteCancion;
            InitializeComponent();
            viewModel = new ViewModelCancion();
            DataContext = viewModel;
        }

        private void BuscarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(BuscarTxt.Text.Trim(), out int id))
            {
                MessageBox.Show("Ingrese un id válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Cancion cancion = clienteCancion.buscarCancion(id);
                    if (cancion == null)
                    {
                        MessageBox.Show("No se encontro una canción con el id dado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        viewModel.Cancion = cancion;
                    }
                }
                catch
                {
                    MessageBox.Show("No se encontro una canción con el id dado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void ActualizarBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fechaLanz = FechaLanzamientoPick.SelectedDate;
            if (fechaLanz == null)
            {
                MessageBox.Show("Seleccione una fecha válida");
                return;
            }
            viewModel.Cancion.fechaLanzamiento = fechaLanz.Value;
            viewModel.Cancion.fechaLanzamientoSpecified = true;
            try
            {
                clienteCancion.actualizarCancion(viewModel.Cancion);
                MessageBox.Show("Canción actualizada correctamente");
            }
            catch
            {
                MessageBox.Show("No se pudo actualizar la canción, tal vez fue eliminada :(");
            }
        }
    }
}
