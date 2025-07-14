using FinanceProject.Models;
using Microsoft.EntityFrameworkCore;
using FinanceProject.Dtos.Stock;

namespace FinanceProject.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStocksAsync();
        Task<Stock?> getStocksByIdAsync(int id); // FirstOrDefault -> returns null if not found
        Task<Stock> CreateStockAsync(Stock stockModel);
        Task<Stock?> UpdateStockAsync(int id, UpdateStockDto stockDto);
        Task<Stock?> DeleteStockAsync(int id);
    }
}
