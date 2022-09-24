﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_Infrastructure.Database.Customer.Repositories;
using CleanArch_Domain.Customer.Repositories;
using CleanArch_Domain.Customer.Entities;
using CleanArch_Infrastructure.Database.Context;
using CleanArch_Infrastructure.Database.Customer.Entities;

namespace CleanArch_Infrastructure.Database.Customer.Repositories
{
     public class CustomerRepository : ICustomerRepository
    {
        private MainDbContext _context;

        public CustomerRepository()
        {
            _context = new MainDbContext();
        }
        public CustomerClass FindCustomer(string email)
        {
            var customerEntity = _context.Customers.Where(customer => customer.Email == email).FirstOrDefault();


            return new CustomerClass()
            {
                Email = customerEntity.Email,
                Name = customerEntity.Name,
                Cpf = customerEntity.Cpf,
                Id = customerEntity.Id,
                PhoneNumber = customerEntity.PhoneNumber
            };
        }

        public CustomerClass CreateCustomer(CustomerClass customer)
        {
            var customerEntity = new CustomerEntity()
            {
                Name = customer.Name,
                Email = customer.Email,
                Cpf = customer.Cpf,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber
            };
             _context.Customers.Add(customerEntity);
              _context.SaveChanges();

            return new CustomerClass()
            {
                Name = customerEntity.Name,
                Email = customerEntity.Email,
                Cpf = customerEntity.Cpf,
                PhoneNumber = customerEntity.PhoneNumber,
                Id = customerEntity.Id
            };


        }
    }
}
