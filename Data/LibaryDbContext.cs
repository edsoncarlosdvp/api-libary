using Libary.Data.Map;
using Libary.Models;
using Microsoft.EntityFrameworkCore;

namespace Libary.Data
{
    public class LibaryDbContext : DbContext
    {
        public LibaryDbContext(DbContextOptions<LibaryDbContext> options) : base(options) { }
        public DbSet<LibaryModel> Libary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LibaryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
