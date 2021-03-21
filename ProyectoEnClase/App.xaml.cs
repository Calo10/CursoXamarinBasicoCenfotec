using System;
using ProyectoEnClase.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoEnClase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new HomeView();    
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
