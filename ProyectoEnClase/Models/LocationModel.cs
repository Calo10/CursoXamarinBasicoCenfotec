using System;
using System.Threading.Tasks;

namespace ProyectoEnClase.Models
{
    public class LocationModel
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string timezone { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }

        public LocationModel()
        {

        }
    }
}
