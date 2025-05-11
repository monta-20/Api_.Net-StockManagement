using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.DTOs.Stock;
using WebApplication1.Mappers;

namespace WebApplication1.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context; 
        public StockRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.FindAsync(id);
        }

        public async Task<Stock> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            stock.ToStockFromUpdateDteo(stockDto);
            await _context.SaveChangesAsync();

            return stock;
        }
    }
}
