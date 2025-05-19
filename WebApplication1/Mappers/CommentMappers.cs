using System.Runtime.CompilerServices;
using WebApplication1.DTOs.Comment;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comments commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatOn = commentModel.CreatOn,
                StockId = commentModel.StockId,
            };
        }

        public static Comments ToCommentFromCreateDto(this CreateCommentDto commentModel , int stockId )
        {
            return new Comments
            {
         
                Title = commentModel.Title,
                Content = commentModel.Content,
                StockId = stockId,
            };
        }

        public static Comments ToCommentFromUpdate(this UpdateCommentRequestDto commentModel, int stockId)
        {
            return new Comments
            {

                Title = commentModel.Title,
                Content = commentModel.Content,
                StockId = stockId,
            };
        }
    }
}
