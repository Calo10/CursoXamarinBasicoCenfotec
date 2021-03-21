﻿using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async static Task<ObservableCollection<DoctorModel>> GetAllDoctors()
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri("https://dummyapi.io/data/api/user?limit=10");

                client.DefaultRequestHeaders.Add("app-id", "5fad867bca750f4fc7508473");

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

                string ans = await response.Content.ReadAsStringAsync();

                ResponseDoctorModel responseObject = JsonConvert.DeserializeObject<ResponseDoctorModel>(ans);

                return responseObject.data;
            }
        }

    }
}
