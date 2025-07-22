using Abcloudz.Models.Interfaces;
using Abcloudz.Models.Models;
using Abcloudz.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Abcloudz.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<UserDocumentModel> UserDocuments => Set<UserDocumentModel>();  

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ICreatable>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
            }

            foreach (var entry in ChangeTracker.Entries<IUpdatable>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
