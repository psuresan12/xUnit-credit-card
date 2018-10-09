using System;
using Microsoft.EntityFrameworkCore;
using TestCards.Models;

namespace TestCards.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :
            base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<CreditCardApplication> CreditCardApplications { get; set; }
    }
}
