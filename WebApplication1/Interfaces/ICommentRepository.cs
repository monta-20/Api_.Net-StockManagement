using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllAsync();
        Task<Comments?> GetByIdAsync(int id);


    }
}
