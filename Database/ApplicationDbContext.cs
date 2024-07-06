using Microsoft.EntityFrameworkCore;
using CustomerAccessControl.Models;

namespace CustomerAccessControl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Entry> Entries { get; set; }
    }
}
