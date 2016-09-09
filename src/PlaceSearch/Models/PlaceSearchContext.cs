using Microsoft.EntityFrameworkCore;

namespace PlaceSearch.Models
{
    public class PlaceSearchContext : DbContext
    {
        public virtual DbSet<Place> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PlaceSearch;integrated security=True");
        }
    }
}