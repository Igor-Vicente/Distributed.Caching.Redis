using Demo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
