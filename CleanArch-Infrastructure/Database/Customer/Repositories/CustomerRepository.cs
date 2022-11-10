using System;
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

        public CustomerRepository(MainDbContext context)
        {
            _context = context;
        }
        public CustomerEntity FindCustomer(string email)
        {
            var customerEntity = _context.Customers.Where(customer => customer.Email == email).FirstOrDefault();
            

            return new CustomerEntity()
            {
                Email = customerEntity.Email,
                Name = customerEntity.Name,
                Cpf = customerEntity.Cpf,
                Id = customerEntity.Id,
                PhoneNumber = customerEntity.PhoneNumber
            };
        }

        public CustomerEntity CreateCustomer(CustomerEntity customer)
        {
            var customerEntity = new CustomerModel()
            {
                Name = customer.Name,
                Email = customer.Email,
                Cpf = customer.Cpf,
                PhoneNumber = customer.PhoneNumber
            };
             _context.Customers.Add(customerEntity);
             _context.SaveChanges();

            return new CustomerEntity()
            {
                Name = customerEntity.Name,
                Email = customerEntity.Email,
                Cpf = customerEntity.Cpf,
                PhoneNumber = customerEntity.PhoneNumber,
                Id = customerEntity.Id
            };


        }
        public  CustomerEntity UpdateCustomer(CustomerEntity customer)
        {
            var customerModel = new CustomerModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Cpf = customer.Cpf,
                PhoneNumber = customer.PhoneNumber
            };
             _context.ChangeTracker.Clear(); 
             _context.Customers.Update(customerModel);
             _context.SaveChanges();

            return new CustomerEntity()
            {
                Name = customerModel.Name,
                Email = customerModel.Email,
                Cpf = customerModel.Cpf,
                PhoneNumber = customerModel.PhoneNumber,
                Id = customerModel.Id
            };
        }
    }
}
