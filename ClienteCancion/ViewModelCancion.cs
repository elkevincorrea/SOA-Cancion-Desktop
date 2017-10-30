using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Cancion = ClienteCancion.CancionSW.cancion;

namespace ClienteCancion
{
    public class ViewModelCancion : INotifyPropertyChanged
    {
        private Cancion cancion;
        public Cancion Cancion
        {
            get {
                if (cancion == null)
                {
                    cancion = new Cancion();
                }
                return cancion;
            }
            set
            {
                cancion = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Id"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Titulo"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Genero"));
                    PropertyChanged(this, new PropertyChangedEventArgs("NombreArtista"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FechaLanzamiento"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Duracion"));
                }
            }
        }

        public int Id
        {
            get { return Cancion.id; }
            set { Cancion.id = value; }
        }

        public string Titulo
        {
            get { return Cancion.titulo; }
            set { Cancion.titulo = value; }
        }

        public string Genero
        {
            get { return Cancion.genero; }
            set { Cancion.genero = value; }
        }

        public string NombreArtista
        {
            get { return Cancion.nombreArtista; }
            set { Cancion.nombreArtista = value; }
        }

        public DateTime FechaLanzamiento
        {
            get { return Cancion.fechaLanzamiento; }
            set {
                Cancion.fechaLanzamientoSpecified = true;
                Cancion.fechaLanzamiento = value;
            } 
        }

        public int Duracion
        {
            get { return Cancion.duracion; }
            set
            {
                Cancion.duracion = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
