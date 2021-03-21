using System;
using System.Collections.Generic;
using ProyectoEnClase.ViewModels;
using Xamarin.Forms;

namespace ProyectoEnClase.Views
{
    public partial class PostView : ContentPage
    {
        public PostView()
        {
            InitializeComponent();

            BindingContext = PostViewModel.GetInstance();
        }
    }
}
