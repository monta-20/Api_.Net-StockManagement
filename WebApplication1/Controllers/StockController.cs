using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTOs.Stock;
using WebApplication1.Mappers;
namespace WebApplication1.Controllers
    
{
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StockController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stock.ToList()
            .Select(s => s.ToStockDto());

            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());

        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            _context.Stock.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id } , stockModel.ToStockDto());
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stock = _context.Stock.Find(id); 
            if(stock == null)
            {
                return NotFound();
            }
            stock.ToStockFromUpdateDteo(updateDto);
            _context.SaveChanges();

            return NoContent(); 
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stock.FirstOrDefault(x => x.Id == id);
            if(stockModel == null)
            {
                return NotFound();
            }
            _context.Stock.Remove(stockModel);
            _context.SaveChanges();
            return NoContent();
        }
    }


}
