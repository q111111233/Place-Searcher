using Microsoft.EntityFrameworkCore;

namespace PlaceSearch.Models
{
    public class MigrationContext : DbContext
    {
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public MigrationContext(DbContextOptions<MigrationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}