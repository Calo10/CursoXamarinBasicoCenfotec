using System;
using System.Collections.Generic;
using ProyectoEnClase.ViewModels;
using Xamarin.Forms;

namespace ProyectoEnClase.Views
{
    public partial class RegisterUserView : ContentPage
    {
        public RegisterUserView()
        {
            InitializeComponent();

            BindingContext = LoginViewModel.GetInstance();
        }
    }
}
