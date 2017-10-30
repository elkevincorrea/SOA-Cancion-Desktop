using System.Windows;
using Cancion = ClienteCancion.CancionSW.cancion;

namespace ClienteCancion
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CancionSW.CancionSWClient clienteCancion;

        public MainWindow()
        {
            clienteCancion = new CancionSW.CancionSWClient();
            InitializeComponent();
        }

        private void ListarBtn_Click(object sender, RoutedEventArgs e)
        {
            (new ListaWindow(clienteCancion)).Show();
        }

        private void AgregarBtn_Click(object sender, RoutedEventArgs e)
        {
            (new AgregarWindow(clienteCancion)).Show();
        }

        private void ConsultarBtn_Click(object sender, RoutedEventArgs e)
        {
            (new ConsultarWindow(clienteCancion)).Show();
        }

        private void ActualizarBtn_Click(object sender, RoutedEventArgs e)
        {
            (new ActualizarWindow(clienteCancion)).Show();
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            (new EliminarWindow(clienteCancion)).Show();
        }
    }
}
