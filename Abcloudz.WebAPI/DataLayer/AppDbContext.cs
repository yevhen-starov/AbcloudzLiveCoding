using Abcloudz.WebAPI.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abcloudz.WebAPI.DataLayer
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
	}

}
