using Microsoft.EntityFrameworkCore;
using Movie_App.Models;

namespace Movie_App.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LatestSearch> LatestSearches { get; set; }
    }
}
