using BethanyPieShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanyPieShop.Infrastructure
{
    public class PieContext : DbContext
    {
        public DbSet<PieOrder> orders { get; set; }

        public PieContext(DbContextOptions<PieContext> contextOptions)
            : base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PieShop");
        }
    }
}