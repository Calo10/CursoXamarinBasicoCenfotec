using System;
using System.Collections.ObjectModel;

namespace ProyectoEnClase.Models
{
    public class ResponsePostModel : ResponseModel
    {

        public ObservableCollection<PostModel> data { get; set; }

        public ResponsePostModel()
        {
        }
    }
}
