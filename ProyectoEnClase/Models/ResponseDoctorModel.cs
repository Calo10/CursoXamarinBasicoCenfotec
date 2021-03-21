using System;
using System.Collections.ObjectModel;

namespace ProyectoEnClase.Models
{
    public class ResponseDoctorModel : ResponseModel
    {
        public ObservableCollection<DoctorModel> data { get; set; }

        public ResponseDoctorModel()
        {
        }
    }
}
