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
        public async Task<List<Comments>> GetAllAsync()
        {

            return await _context.Comments.ToListAsync(); 
        }
    }
}
