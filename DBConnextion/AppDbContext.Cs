using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace statistique2.DBConnextion
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=statistique;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options){}
        
        public DbSet<Famous> Famous { get; set; }
        public DbSet<Follower> Followers { get; set; }
    }
}

