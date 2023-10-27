using AppComida.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppComida.ViewModels
{
    class Comentarios : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region IMAGEN DE BOTON
        public Command CargarImagen { get; }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        private FileResult _imageResult;
        public FileResult ImageResult
        {
            get => _imageResult;
            set
            {
                _imageResult = value;
                OnPropertyChanged();
            }
        }

        public async void AgregarFoto(object obj)
        {
            var foto = await MediaPicker.PickPhotoAsync();
            if (foto != null)
            {
                ImageResult = foto;
                var memoriaStream = await foto.OpenReadAsync();
                ImageSource = ImageSource.FromStream(() => memoriaStream);
                await App.Current.MainPage.DisplayAlert("Imagen", "Imagen Subida con exito", "Aceptar");

            }
            
        }

       
        #endregion

        #region TEXTO O COMENTARIO
        private string _texto;
        public string Texto
        {
            get => _texto;
            set
            {
                _texto = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region LISTA DE COMENTARIOS
        public ObservableCollection<ComentarioModel> Comentario
        {
            get;
        } = new ObservableCollection<ComentarioModel>();
        #endregion

        #region AGREGAR COMENTARIO

        //DAMARIS A SAM Y AMEL NO MOVER NADA
        public Command InsertarComentario { get; }

        public async void ComentarioInsertar(object obj)
        {
            var memoriaStream = await _imageResult.OpenReadAsync();
            if ((Comentario != null && !string.IsNullOrEmpty(Texto)))
            {
                
                Comentario.Add(new ComentarioModel()
                {
                    Source = ImageSource.FromStream(() => memoriaStream),
                    Comentario = this.Texto
                });
                OnPropertyChanged(nameof(Comentario));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Agregar Comentario", "Favor de llenar el comentario o subir foto", "Aceptar");
            }
        }
        #endregion

        public Comentarios()
        {
            CargarImagen = new Command(AgregarFoto);
            InsertarComentario = new Command(ComentarioInsertar);
        }
    }
}
