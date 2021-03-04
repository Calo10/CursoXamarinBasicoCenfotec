using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProyectoEnClase.Models;

namespace ProyectoEnClase.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<DoctorModel> _lstDoctors = new ObservableCollection<DoctorModel>();
        public ObservableCollection<DoctorModel> lstDoctors
        {
            get
            {
                return _lstDoctors;
            }
            set
            {
                _lstDoctors = value;
                OnPropertyChanged("lstDoctors");
            }
        }
        #endregion


        #region Singleton

        private static HomeViewModel instance = null;

        private HomeViewModel()
        {
            //InitCommands();
            InitClass();
        }

        public static HomeViewModel GetInstance()
        {
            if (instance == null)
                instance = new HomeViewModel();

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
            lstDoctors.Add(new DoctorModel { FirstName = "Joe", LastName = "Doe", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { FirstName = "John", LastName = "Merkel", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { FirstName = "Carl", LastName = "Heinz", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { FirstName = "Megan", LastName = "Scott", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            lstDoctors.Add(new DoctorModel { FirstName = "Silvia", LastName = "Mars", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
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
