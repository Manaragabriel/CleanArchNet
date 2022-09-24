using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_Infrastructure.Database.Customer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Infrastructure.Database.Context
{
    public class MainDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=;database=cleanArch", new MySqlServerVersion(new Version(8, 0, 29)));
        }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
