using System;
using System.Collections.Generic;
using ProyectoEnClase.ViewModels;
using Xamarin.Forms;

namespace ProyectoEnClase.Views
{
    public partial class InfoView : ContentPage
    {
        public InfoView()
        {
            InitializeComponent();

            BindingContext = MenuViewModel.GetInstance();
        }
    }
}
