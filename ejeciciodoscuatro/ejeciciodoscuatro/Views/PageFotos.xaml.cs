using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ejeciciodoscuatro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFotos : ContentPage
    {
        public PageFotos()
        {
            InitializeComponent();
            cargarList();
        }
        public async void cargarList()
        {
            var fotoList = await App.SQLiteBD.GetFotoAsync();
            if (fotoList != null)
            {
                lstFotos.ItemsSource = fotoList;
            }
        }
    }
}