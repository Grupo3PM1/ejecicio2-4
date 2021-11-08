using ejeciciodoscuatro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection;

namespace ejeciciodoscuatro
{
    public partial class MainPage : ContentPage
    {
        public bool takedfoto = false;
        public byte[] imgbyte;
        public Image image = new Image();
        public MainPage()
        {
            InitializeComponent();
            TakePhoto.Clicked += TakePhoto_Clicked;
            SearchPhoto.Clicked += SearchPhoto_Clicked;
        }

        private async void SearchPhoto_Clicked(object sender, EventArgs e)
        {
            if (validarDatosAsync())
            {
                foto fot = new foto
                {
                    Imagen = imgbyte,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                };
                await App.SQLiteBD.SavedFotoAsync(fot);
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                Photo.Source = ImageSource.FromFile("noimagen.png");
                takedfoto = false;
                await DisplayAlert("Wow", "ESOOOOOOOOOOO", "OK");
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingrese todos los datos", "OK");
            }
        }
        public bool validarDatosAsync()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;

            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                respuesta = false;

            }
            else if (takedfoto == false)
            {
                respuesta = false;

            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var photo =
               await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());
            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    
                    takedfoto = true;
                    image.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                    using (MemoryStream memory = new MemoryStream())
                    {

                        Stream stream = photo.GetStream();
                        stream.CopyTo(memory);
                        imgbyte = memory.ToArray();
                    }
                    return photo.GetStream();
                });
            }
            else
            {
                await DisplayAlert("Error", "No hay foto", "OK");
            }
        }


    }
}
