using Final_Project.Models;
using Microsoft.EntityFrameworkCore;


namespace Final_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
       
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=FinalProject;Trusted_Connection=True;TrustServerCertificate=True");
        //}
    }
}
