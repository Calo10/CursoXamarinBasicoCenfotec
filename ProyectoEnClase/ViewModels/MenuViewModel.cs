using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ProyectoEnClase.Models;
using ProyectoEnClase.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProyectoEnClase.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<MenuModel> _lstMenu = new ObservableCollection<MenuModel>();
        public ObservableCollection<MenuModel> lstMenu
        {
            get
            {
                return _lstMenu;
            }
            set
            {
                _lstMenu = value;
                OnPropertyChanged("lstMenu");
            }
        }

        private string _batteryLevel = "";

        public string batteryLevel
        {
            get
            {
                return _batteryLevel;
            }
            set
            {
                _batteryLevel = value;
                OnPropertyChanged("batteryLevel");
            }
        }

        public ICommand EnterMenuOptionCommand { get; set; }

        #endregion


        #region Singleton

        private static MenuViewModel instance = null;

        private MenuViewModel()
        {
            InitCommands();
            InitClass();
        }

        public static MenuViewModel GetInstance()
        {
            if (instance == null)
                instance = new MenuViewModel();

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
                instance = null;
        }
        #endregion

        public void InitClass()
        {
            lstMenu.Add(new MenuModel { Id = 1, Name = "Specialties", Icon = "" });
            lstMenu.Add(new MenuModel { Id = 2, Name = "Contact", Icon = "" });
            lstMenu.Add(new MenuModel { Id = 3, Name = "Information", Icon = "" });
            lstMenu.Add(new MenuModel { Id = 4, Name = "Map", Icon = "" });
            lstMenu.Add(new MenuModel { Id = 5, Name = "Chat", Icon = "" });

            //batteryLevel = Battery.ChargeLevel.ToString();
        }

        public void InitCommands()
        {
            EnterMenuOptionCommand = new Command<int>(EnterMenuOption);
        }

        public async void EnterMenuOption(int opc)
        {
            switch (opc)
            {
                case 1:
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new SpecialtiesView());
                    break;
                case 2:
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ContactView());
                    break;

                case 3:
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new InfoView());
                    break;

                case 4:
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MapView());
                    break;

                case 5:
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ChatView());
                    break;

                default:
                    break;
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
