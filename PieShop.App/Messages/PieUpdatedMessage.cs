using CommunityToolkit.Mvvm.Messaging.Messages;
using PieShop.App.Models;

namespace PieShop.App.Message
{
    public class PieUpdatedMessage : ValueChangedMessage<Pie>
    {
        public PieUpdatedMessage(Pie value) : base(value)
        {
        }
    }
}
