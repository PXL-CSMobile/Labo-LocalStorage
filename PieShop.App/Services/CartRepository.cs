using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieShop.App.Models;
using SQLite;

namespace PieShop.App.Services
{


    public class CartRepository : ICartRepository
    {
        private SQLiteAsyncConnection _database;

        public async Task AddToCartAsync(Pie pie)
        {
            await Init();

            var item = await _database.Table<CartItem>().FirstOrDefaultAsync(i => i.PieId == pie.Id);

            if(item is not null)
            {
                item.Quantity++;
                await _database.UpdateAsync(item);
            }
            else
            {
                item = new CartItem();
                item.PieId = pie.Id;
                item.Price = pie.Price;
                item.PieName = pie.PieName;
                item.Quantity = 1;
                await _database.InsertAsync(item);
            }
        }

        public async Task<List<CartItem>> GetAllItemsAsync()
        {
            await Init();
            return await _database.Table<CartItem>().ToListAsync();
        }

        public async Task UpdateQuantityAsync(int itemId, int quantity)
        {
            var item = await _database.Table<CartItem>().FirstOrDefaultAsync(i => i.Id == itemId);

            if (item is not null)
            {
                item.Quantity = quantity;
                await _database.UpdateAsync(item);
            }
        }

        public async Task RemoveFromCartAsync(int itemId)
        {
            await _database.Table<CartItem>().DeleteAsync(i => i.Id == itemId);
        }

        private async Task Init()
        {
            if (_database is not null)
                return;

            // Get an absolute path to the database file
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "PieCart.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            await _database.CreateTableAsync<CartItem>();
        }
    }
}
