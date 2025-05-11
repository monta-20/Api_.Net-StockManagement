using WebApplication1.DTOs.Stock;
using WebApplication1.Models;
namespace WebApplication1.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock> UpdateAsync(int id ,UpdateStockRequestDto stockDto);
        Task<Stock> DeleteAsync(int id);




    }
}
