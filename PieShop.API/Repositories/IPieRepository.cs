using PieShop.API.Entities;

namespace PieShop.API.Repositories
{
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> GetPiesAsync();
        Task<Pie?> GetPieAsync(Guid id);
        Task<Pie> AddPieAsync(Pie pie);
        Task UpdatePieAsync(Pie pie);
        Task DeletePieAsync(Pie pie);
    }
}
