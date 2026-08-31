using GenericRepositoryPattern.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPattern.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> option):base(option)
        {
            
        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
