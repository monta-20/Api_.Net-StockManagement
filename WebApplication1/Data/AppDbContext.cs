using Microsoft.EntityFrameworkCore;
using WebApplication1.Models; // Adapté à votre projet

namespace WebApplication1.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Stock> Stock { get; set; }

		public DbSet<Comments> Comments { get; set; }
	}
}
