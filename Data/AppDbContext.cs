using Microsoft.EntityFrameworkCore;
using Wingslompson.Models;

namespace Wingslompson.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wings> Wings { get; set; }
        public object? Wingsons { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
    

