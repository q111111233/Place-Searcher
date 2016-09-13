using Microsoft.EntityFrameworkCore;

namespace PlaceSearch.Models
{
    public class PlaceSearchContext : DbContext
    {
        public DbSet<Place> Places { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public PlaceSearchContext(DbContextOptions<PlaceSearchContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}