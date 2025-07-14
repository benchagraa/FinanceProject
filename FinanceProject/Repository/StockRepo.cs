using FinanceProject.Data;
using FinanceProject.Dtos.Stock;
using FinanceProject.Interfaces;
using FinanceProject.Mappers;
using FinanceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceProject.Repository
{
    public class StockRepo : IStockRepository
    {

        private readonly ApplicationDbContext _context;

        public StockRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> getStocksByIdAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            return stock;
        }

        public async Task<Stock> CreateStockAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> UpdateStockAsync(int id, UpdateStockDto stockDto)
        {
            var stock = await this.getStocksByIdAsync(id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Update(stockDto.ToStockFromUpdateStockDto(stock));
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<Stock?> DeleteStockAsync(int id)
        {
            var stock = await this.getStocksByIdAsync(id);
            if (stock == null) { 
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }
    }
}
