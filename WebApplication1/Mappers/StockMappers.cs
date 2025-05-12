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
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            purchase = stockModel.purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),
        };
    }

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            purchase = stockDto.purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };

    }

    public static void ToStockFromUpdateDteo(this Stock stock, UpdateStockRequestDto dto)
    {
        stock.Symbol = dto.Symbol;
        stock.CompanyName = dto.CompanyName;
        stock.purchase = dto.purchase;
        stock.LastDiv = dto.LastDiv;
        stock.Industry = dto.Industry;
        stock.MarketCap = dto.MarketCap;

    }

}
