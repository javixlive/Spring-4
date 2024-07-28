using BollywoodHubAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;



namespace BollywoodHubAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> User { get; set; }
        public DbSet<Movies> Movie { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
    }
}
