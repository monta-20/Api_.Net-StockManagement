﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
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
    }


}
