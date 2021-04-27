using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ProyectoEnClase.ViewModels;
using Xamarin.Forms;

namespace ProyectoEnClase.Views
{
    public partial class ChatView : ContentPage
    {
        public ICommand ScrollListCommand { get; set; }
        public ChatView()
        {
            InitializeComponent();

            BindingContext = new ChatPageViewModel();

            ScrollListCommand = new Command(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                  ChatList.ScrollTo((this.BindingContext as ChatPageViewModel).Messages.Last(), ScrollToPosition.End, true)
              );
            });
        }
    }
}
