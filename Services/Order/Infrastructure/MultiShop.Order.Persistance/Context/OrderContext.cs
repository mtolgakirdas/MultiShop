using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;Database=MultiShopOrderDb; TrustServerCertificate=true; User Id=sa;Password =1478963258tT*");
        }
        public DbSet<Address> Addresses   { get; set; }
        public DbSet<OrderDetail> OrderDetails   { get; set; }
        public DbSet<Ordering> Orderings   { get; set; }
    }
}
