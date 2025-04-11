using Microsoft.EntityFrameworkCore;
using POSApi.Models.Entities;

namespace POSApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        //{

        //}

        //protected ApplicationDbContext()
        //{
        //}

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees    { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }


    }
}
