🏗️ Repository Pattern & Dependency Injection in ASP.NET Core
📘 What is the Repository Pattern?
The Repository Pattern is a design pattern that separates the data access logic from the business logic in your application.

It acts as a mediator between the database layer and the controller, offering a clean and abstract way to interact with data.

✅ Why Use It?
Keeps controller logic clean.

Makes the data access layer reusable.

Simplifies testing and maintenance.

Supports loose coupling and separation of concerns.

🔧 Implementing the Repository Pattern
1. 🧱 Define an Interface
csharp

// Repositories/IStockRepository.cs
public interface IStockRepository
{
    Task<IEnumerable<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> AddAsync(Stock stock);
    Task<Stock?> UpdateAsync(int id, Stock stock);
    Task<bool> DeleteAsync(int id);
}
2. 🧰 Implement the Interface
csharp

// Repositories/StockRepository.cs
public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;

    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        return await _context.Stock.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stock.FindAsync(id);
    }

    public async Task<Stock> AddAsync(Stock stock)
    {
        _context.Stock.Add(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateAsync(int id, Stock stock)
    {
        var existing = await _context.Stock.FindAsync(id);
        if (existing == null) return null;

        existing.Symbol = stock.Symbol;
        existing.CompanyName = stock.CompanyName;
        // ... update other fields

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var stock = await _context.Stock.FindAsync(id);
        if (stock == null) return false;

        _context.Stock.Remove(stock);
        await _context.SaveChangesAsync();
        return true;
    }
}
💉 Dependency Injection (DI)
📘 What is DI?
Dependency Injection is a technique where an object’s dependencies are provided externally, rather than created inside the object. ASP.NET Core has built-in support for DI.

🔌 Register the Repository in Program.cs
csharp

builder.Services.AddScoped<IStockRepository, StockRepository>();
This tells ASP.NET Core to inject the StockRepository wherever IStockRepository is required.

🌐 Use in Controller
csharp

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly IStockRepository _stockRepository;

    public StockController(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await _stockRepository.GetAllAsync();
        return Ok(stocks);
    }
}
🧠 Summary
Concept	                                             Role
Repository Pattern	              Decouples business logic from data access
Interface	                      Defines contracts for repositories
Implementation	                  Contains real EF Core logic
DI Container	                  Manages and injects services (like repositories)
Controller	                      Uses injected repository instead of direct DB access