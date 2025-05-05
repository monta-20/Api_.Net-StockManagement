using Microsoft.EntityFrameworkCore;


namespace EfDemo.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Stock> Stock { get; set; }

		public Dbset<Comments> Comments { get; set; }
	}
}
