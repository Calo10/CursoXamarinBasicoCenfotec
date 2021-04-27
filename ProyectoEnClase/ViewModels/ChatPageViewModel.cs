using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ProyectoEnClase.Models;
using Xamarin.Forms;

namespace ProyectoEnClase.ViewModels
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {

        #region Properties

        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }

        #endregion



        public ChatPageViewModel()
        {
            InitClass();
            InitCommands();
        }

        public async void InitClass()
        {
            Messages.Add(new MessageModel() { Text = "Hi" });
            Messages.Add(new MessageModel() { Text = "How are you?" });
        }

        private void InitCommands()
        {
            OnSendCommand = new Command(OnSend);
        }

        public void OnSend()
        {
            if (!string.IsNullOrEmpty(TextToSend))
            {
                Messages.Add(new MessageModel() { Text = TextToSend, User = "User1" });
                TextToSend = string.Empty;
            }
        }

        #region INotifyPropertyChanged Implentation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
