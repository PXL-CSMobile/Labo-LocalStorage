using CommunityToolkit.Mvvm.Messaging.Messages;
using PieShop.App.Models;

namespace PieShop.App.Message
{
    public class PieCreatedMessage : ValueChangedMessage<Pie>
    {
        public PieCreatedMessage(Pie value) : base(value)
        {
        }
    }
}
