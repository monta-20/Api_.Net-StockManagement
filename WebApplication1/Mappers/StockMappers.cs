using WebApplication1.DTOs.Stock;
using WebApplication1.Models;
namespace WebApplication1.Mappers;  

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            CompanyName = stockModel.CompanyName,
            purchase = stockModel.purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap
        };
    }
}
