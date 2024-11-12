using Entities.models;
using Microsoft.EntityFrameworkCore;
using repository.configurations;

namespace repository
{
    public class repositoryContext : DbContext
    {
        public repositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CurtainsConfigure());
        }

        public DbSet<curtains>? Curtains { get; set; }
    }
}
