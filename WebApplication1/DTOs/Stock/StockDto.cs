using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.DTOs.Comment;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal purchase { get; set; }    
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public required List<CommentDto> Comments { get; set; }


       
    }
}
