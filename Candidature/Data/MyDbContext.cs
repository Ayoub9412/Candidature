using Candidature.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidature.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
