using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProyectoEnClase.Models;

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
        #endregion


        #region Singleton

        private static MenuViewModel instance = null;

        private MenuViewModel()
        {
            //InitCommands();
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
            lstMenu.Add(new MenuModel { Id = 1, Name = "Especialidades", Icon = "" });
            lstMenu.Add(new MenuModel { Id = 1, Name = "Contacto", Icon = "" });
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
