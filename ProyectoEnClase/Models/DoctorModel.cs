using System;
namespace ProyectoEnClase.Models
{
    public class DoctorModel
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Phone { get; set; }


        public DoctorModel()
        {
        }
    }
}
