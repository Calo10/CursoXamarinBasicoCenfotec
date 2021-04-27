using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ProyectoEnClase.Models;
using ProyectoEnClase.Views;
using Xamarin.Essentials;
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

        public ICommand NavigateToMapCommand { get; set; }

        public ICommand EnterDoctorDetailCommand { get; set; }
        public ICommand EnterLocationViewCommand { get; set; }

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
            NavigateToMapCommand = new Command(NavigateToMap);

            EnterDoctorDetailCommand = new Command<string>(EnterDoctorDetail);
            EnterLocationViewCommand = new Command(EnterLocationView);
        }

        public async void EnterDoctorDetail(string Id)
        {

            //DET DETAIL
            //CurrentDoctor = lstDoctors.Where(x => x.Id == Id).FirstOrDefault();
            CurrentDoctor = await DoctorModel.GetDoctorDetail(Id);


            await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new DoctorDetailView());
        }

        public async void EnterLocationView()
        {
            await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new LocationView());
        }

        public async void NavigateToMap()
        {

            try
            {
                var address = CurrentDoctor.Location.street + "%20" + CurrentDoctor.Location.city + "%20" + CurrentDoctor.Location.state + "%20" + CurrentDoctor.Location.country;

                var latLog = await GeocodeModel.GetGeoCode(address);

                var location = new Xamarin.Essentials.Location(latLog.data.results[0].geometry.location.lat, latLog.data.results[0].geometry.location.lng);

                await Map.OpenAsync(location);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", "Error display Map" + ex.Message, "OK");
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
