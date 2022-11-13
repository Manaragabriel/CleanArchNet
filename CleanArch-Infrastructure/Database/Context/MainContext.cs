﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_Infrastructure.Database.Customer.Entities;
using CleanArch_Infrastructure.Database.User.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Infrastructure.Database.Context
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        { }
        public MainDbContext() 
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=user;password=user;database=clean_arch_ref_database", new MySqlServerVersion(new Version(8, 0, 29)));

            }
        }
        public virtual DbSet<CustomerModel> Customers { get; set; }

        public DbSet<UserModel> Users { get; set; }
    }
}
