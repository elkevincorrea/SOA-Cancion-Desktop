using System.Collections.Generic;
using System.Windows;
using Cancion = ClienteCancion.CancionSW.cancion;

namespace ClienteCancion
{
    /// <summary>
    /// Interaction logic for ListaWindow.xaml
    /// </summary>
    public partial class ListaWindow : Window
    {
        private CancionSW.CancionSWClient clienteCancion;

        public ListaWindow(CancionSW.CancionSWClient clienteCancion)
        {
            this.clienteCancion = clienteCancion;
            InitializeComponent();
            try
            {
                CancionesGrid.ItemsSource = this.clienteCancion.listarCanciones();
            }
            catch
            {
                CancionesGrid.ItemsSource = new List<Cancion>();
            }
        }

        private void ActualizarBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CancionesGrid.ItemsSource = clienteCancion.listarCanciones();
            }
            catch
            {
                CancionesGrid.ItemsSource = new List<Cancion>();
            }
        }
    }
}
