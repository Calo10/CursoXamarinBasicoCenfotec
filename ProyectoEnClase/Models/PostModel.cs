using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoEnClase.Models
{
    public class PostModel
    {

        public string text { get; set; }
        public string image { get; set; }
        public int likes { get; set; }
        public string link { get; set; }
        public List<Tag> tags { get; set; }
        public string publishDate { get; set; }
        public UserModel owner { get; set; }

        public async static Task<ObservableCollection<PostModel>> GetAllPostFromDoctor(string id)
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri("https://dummyapi.io/data/api/user/" + id + "/post");

                client.DefaultRequestHeaders.Add("app-id", "5fad867bca750f4fc7508473");

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

                string ans = await response.Content.ReadAsStringAsync();

                ResponsePostModel responseObject = JsonConvert.DeserializeObject<ResponsePostModel>(ans);

                return responseObject.data;
            }
        }

        public PostModel()
        {
        }
    }

    public class Tag
    {
        public string title { get; set; }
    }
}
