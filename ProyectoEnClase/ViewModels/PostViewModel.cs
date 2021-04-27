using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProyectoEnClase.Models;

namespace ProyectoEnClase.ViewModels
{
    public class PostViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<PostModel> _lstPosts = new ObservableCollection<PostModel>();
        public ObservableCollection<PostModel> lstPosts
        {
            get
            {
                return _lstPosts;
            }
            set
            {
                _lstPosts = value;
                OnPropertyChanged("lstPosts");
            }
        }

        #endregion

        #region Singleton

        private static PostViewModel instance = null;

        private PostViewModel()
        {
            InitCommands();
            InitClass();
        }

        public static PostViewModel GetInstance()
        {
            if (instance == null)
                instance = new PostViewModel();

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
                instance = null;
        }
        #endregion

        public async void InitClass()
        {

        }

        private void InitCommands()
        {

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
