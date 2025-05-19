using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<Comments?> CreateAsync(Comments commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comments>> GetAllAsync()
        {

            return await _context.Comments.ToListAsync(); 
        }

        public async Task<Comments?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comments?> UpdateAsync(int id, Comments commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment != null)
            {
                return null; 
            }
            existingComment.Title  = commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}
