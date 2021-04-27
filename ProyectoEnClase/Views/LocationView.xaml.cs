using System;
using System.Collections.Generic;
using ProyectoEnClase.ViewModels;
using Xamarin.Forms;

namespace ProyectoEnClase.Views
{
    public partial class LocationView : ContentPage
    {
        public LocationView()
        {
            InitializeComponent();

            BindingContext = HomeViewModel.GetInstance();
        }
    }
}
