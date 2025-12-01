using PieShop.App.Models;

namespace PieShop.App.Services
{
    public interface IPieRepository
    {
        Task AddPie(Pie pie);
        Task UpdatePie(Pie pie);
        Task<Pie> GetPie(Guid id);
        Task<List<Pie>> GetAllPies();
    }
}
