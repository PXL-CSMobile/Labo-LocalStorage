using Microsoft.EntityFrameworkCore;
using PieShop.API.Data;
using PieShop.API.Entities;

namespace PieShop.API.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext _context;

        public PieRepository(PieShopDbContext context)
        {
            _context = context;
        }

        public async Task<Pie?> GetPieAsync(Guid id)
        {
            return await _context.Pies.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pie>> GetPiesAsync()
        {
            return await _context.Pies.OrderBy(p => p.Name).AsNoTracking().ToListAsync();
        }

        public async Task<Pie> AddPieAsync(Pie pie)
        {
            await _context.Pies.AddAsync(pie);
            await _context.SaveChangesAsync();
            return pie;
        }

        public async Task DeletePieAsync(Pie pie)
        {
            _context.Pies.Remove(pie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePieAsync(Pie pie)
        {
            _context.Pies.Update(pie);
            await _context.SaveChangesAsync();
        }
    }
}
