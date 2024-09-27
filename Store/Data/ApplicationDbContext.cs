using Microsoft.EntityFrameworkCore;
using Store.Model;

namespace Store.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Products> Products { get; set; }
	}
}
