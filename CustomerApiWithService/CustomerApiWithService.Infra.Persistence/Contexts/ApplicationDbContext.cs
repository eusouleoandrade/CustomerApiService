using CustomerApiWithService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerApiWithService.Infra.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        // Properties - DbSets
        public DbSet<Customer> Customers { get; set; }

        // Ctors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
