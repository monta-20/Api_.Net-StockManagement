# 📦 Data Transfer Object (DTO) in ASP.NET Core

## 📘 What is a DTO?

A **DTO (Data Transfer Object)** is a simple object used to transfer data between software layers. In ASP.NET Core Web APIs, it's commonly used to:

- Avoid exposing the internal structure of your database models.
- Limit or customize the data sent to the frontend.
- Improve security and performance by sending only necessary information.

---

## 🎯 Why Use DTOs?

**Without DTOs**:  
You're exposing full entities (e.g., including sensitive or unnecessary fields).

**With DTOs**:  
You send only the required data to clients, in the shape you control.

---

## 🧪 Example: Stock Management API

### 🧩 1. Entity Model (`Stock.cs`)
```csharp
// Models/Stock.cs
namespace WebApplication1.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; }
        public long MarketCap { get; set; }
    }
}

### 📤 2. DTO Definition (StockDto.cs)
// DTOs/Stock/StockDto.cs
namespace WebApplication1.DTOs.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Purchase { get; set; }
    }
}
📝 This class contains only the fields we want to return to the client.

🔁 3. Mapper Extension (StockMappers.cs)

// Mappers/StockMappers.cs
using WebApplication1.DTOs.Stock;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase
            };
        }
    }
}
✅ This static method maps a full Stock entity to a StockDto.

🌐 4. API Controller (StockController.cs)

var stocks = _context.Stock
                                 .Select(s => s.ToStockDto())
                                 .ToList();

 return Ok(stock.ToStockDto());

 🧠 Summary
Concept	                   Purpose
Entity	           Represents the DB structure (EF Core)
DTO	               Represents the API response structure
Mapper	           Converts Entity → DTO
Controller	       Uses DTOs to return clean data


Link for more understand : https://medium.com/@20011002nimeth/understanding-data-transfer-objects-dtos-in-c-net-best-practices-examples-fe3e90238359