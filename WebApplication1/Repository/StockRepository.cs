using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context; 
        public StockRepository(AppDbContext context) {
            _context = context;
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stock.ToListAsync();
        }
    }
}
