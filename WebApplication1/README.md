📩 POST Method in ASP.NET Core
🧠 What is a POST Method?
The POST method is used to send data from the client to the server—commonly to create a new resource (e.g., insert a new row into the database). In ASP.NET Core Web API, this is done via the [HttpPost] attribute in a controller.

🧱 Typical Flow
Client sends a JSON object (like from a frontend or Postman).

Controller receives the object and maps it to a DTO.

The server maps the DTO to a Model (Entity) and saves it to the Database.

🔄 Example Flow: Adding a New Stock
1. 📥 JSON from the Client
json
Copier
Modifier
{
  "symbol": "NFLX",
  "companyName": "Netflix Inc.",
  "purchase": 402.15
}
2. 🔐 StockDto.cs
csharp
Copier
Modifier
public class CreateStockDto
{
    public string Symbol { get; set; }
    public string CompanyName { get; set; }
    public decimal Purchase { get; set; }
}
3. 🧰 Mapper: StockMappers.cs
csharp
Copier
Modifier
public static Stock ToStockFromDto(this CreateStockDto dto)
{
    return new Stock
    {
        Symbol = dto.Symbol,
        CompanyName = dto.CompanyName,
        Purchase = dto.Purchase
    };
}
4. 🌐 Controller
csharp
Copier
Modifier
[HttpPost]
public IActionResult Create([FromBody] CreateStockDto stockDto)
{
    var stock = stockDto.ToStockFromDto();
    _context.Stock.Add(stock);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
}
✅ Summary
Component	                  Role
DTO	             Defines the shape of the data sent
Mapper	         Converts DTO to Entity (and vice versa)
Controller	     Receives data, saves to database
POST Endpoint	 Adds a new resource (e.g., Stock)