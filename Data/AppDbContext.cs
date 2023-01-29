using ClothesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesApi.Data;
public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options) {	}

	public DbSet<Product> Products { get; set; }
}