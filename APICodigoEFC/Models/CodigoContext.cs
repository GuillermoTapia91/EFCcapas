using Microsoft.EntityFrameworkCore;
using System;

namespace APICodigoEFC.Models
{
    public class CodigoContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public CodigoContext(DbContextOptions<CodigoContext> options) : base(options)
        {
        }
    }
}
