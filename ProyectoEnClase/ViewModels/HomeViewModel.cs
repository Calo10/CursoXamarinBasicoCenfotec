using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ProyectoEnClase.Models;
using ProyectoEnClase.Views;
using Xamarin.Forms;

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

        private DoctorModel _CurrentDoctor = new DoctorModel();
        public DoctorModel CurrentDoctor
        {
            get
            {
                return _CurrentDoctor;
            }
            set
            {
                _CurrentDoctor = value;
                OnPropertyChanged("CurrentDoctor");
            }
        }
        #endregion

        #region Commands

        public ICommand EnterDoctorDetailCommand { get; set; }

        #endregion

        #region Singleton

        private static HomeViewModel instance = null;

        private HomeViewModel()
        {
            InitCommands();
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


        public async void InitClass()
        {
            lstDoctors = await DoctorModel.GetAllDoctors();

            //lstDoctors.Add(new DoctorModel { Id = "1", FirstName = "Joe", LastName = "Doe", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            //lstDoctors.Add(new DoctorModel { Id = "2", FirstName = "John", LastName = "Merkel", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            //lstDoctors.Add(new DoctorModel { Id = "3", FirstName = "Carl", LastName = "Heinz", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            //lstDoctors.Add(new DoctorModel { Id = "4", FirstName = "Megan", LastName = "Scott", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
            //lstDoctors.Add(new DoctorModel { Id = "5", FirstName = "Silvia", LastName = "Mars", Email = "test@test.com", Picture = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg" });
        }

        private void InitCommands()
        {
            EnterDoctorDetailCommand = new Command<string>(EnterDoctorDetail);
        }

        public async void EnterDoctorDetail(string Id)
        {

            CurrentDoctor = lstDoctors.Where(x => x.Id == Id).FirstOrDefault();

            await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new DoctorDetailView());

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
