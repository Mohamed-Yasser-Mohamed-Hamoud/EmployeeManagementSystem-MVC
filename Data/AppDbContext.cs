using Learning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Learning.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>Options):base(Options)
        {

        }
        public DbSet<Item>Items { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Employee>Employees { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { category_id = 1, category_name = "computer" },
                new Category() { category_id = 2, category_name = "mobile" },
                new Category() { category_id = 3, category_name = "Electric machines" }
                );
            modelBuilder.Entity<IdentityRole>().HasData(
    new IdentityRole
    {
        Id = "11111111-1111-1111-1111-111111111111",
        Name = "Admin",
        NormalizedName = "ADMIN",
        ConcurrencyStamp = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"
    },
    new IdentityRole
    {
        Id = "22222222-2222-2222-2222-222222222222",
        Name = "User",
        NormalizedName = "USER",
        ConcurrencyStamp = "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"
    }
);
            base.OnModelCreating(modelBuilder);
        }
    }
}
