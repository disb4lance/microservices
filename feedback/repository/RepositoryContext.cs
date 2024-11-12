using Entities.models;
using Microsoft.EntityFrameworkCore;
namespace repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<feedbackmodel>? Feedbacks { get; set; }

    }
}
