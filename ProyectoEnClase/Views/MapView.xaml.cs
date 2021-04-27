using System;
using System.Collections.Generic;
using ProyectoEnClase.ViewModels;
using Xamarin.Forms;

namespace ProyectoEnClase.Views
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();

            BindingContext = new MapViewModel();
        }
    }
}
