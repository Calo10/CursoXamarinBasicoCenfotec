using System;
using ProyectoEnClase.Models;
using ProyectoEnClase.Views.Cells;
using Xamarin.Forms;

namespace ProyectoEnClase.Helpers
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as MessageModel;
            if (message == null)
                return null;

            return (message.User == "User1") ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
