﻿using System;
using System.Collections.Generic;
using ProyectoEnClase.ViewModels;
using Xamarin.Forms;

namespace ProyectoEnClase.Views
{
    public partial class DoctorDetailView : ContentPage
    {
        public DoctorDetailView()
        {
            InitializeComponent();

            BindingContext = HomeViewModel.GetInstance();
        }
    }
}
