using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Comment;
using WebApplication1.Interfaces;
using WebApplication1.Mappers;

namespace WebApplication1.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo; 
        public CommentController(ICommentRepository commentRepo , IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto()); 
            return Ok(commentDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{stockId}")] 
        public async Task<IActionResult> Create([FromRoute] int stockId  , CreateCommentDto commentDto , IStockRepository IStockRepo )
        {
            if (!await IStockRepo.StockExists(stockId))
            {
                return BadRequest("stock does not exist");
            }
            var commentModel = commentDto.ToCommentFromCreateDto(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById) , new {id = commentModel} ,commentModel.ToCommentDto() );

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id , [FromBody] UpdateCommentRequestDto updateDto)
        {
            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate(id));
            if (comment == null)
            {
                NotFound("Comment Not Found");
            }
            return Ok(comment.ToCommentDto());
        }
    }
}
