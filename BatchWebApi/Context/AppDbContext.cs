using BatchWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BatchWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Batch> Batches { get; set; }
    }
}
