using PieShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.App.Services
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetAllItemsAsync();
        Task AddToCartAsync(Pie pie);
        Task UpdateQuantityAsync(int itemId, int quantity);
        Task RemoveFromCartAsync(int itemId);
    }
}
