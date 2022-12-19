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
using CleanArch_Infrastructure.Database.DapperConnection;
using Dapper;

namespace CleanArch_Infrastructure.Database.Customer.Repositories
{
     public class CustomerRepository : ICustomerRepository
    {
        private MainDbContext _context;
        private DapperCon _dapper;

        public CustomerRepository(MainDbContext context)
        {
            _context = context;
            _dapper = new DapperCon();

        }
       
        public IEnumerable<CustomerEntity> FindCustomers()
        {
            var customersModels = _dapper.connection.Query<CustomerModel>("SELECT * FROM Customers C where C.Email = 'teste@teste.com' ").ToList();
            var customers = new List<CustomerEntity>();
            foreach (var customerModel in customersModels)
            {
                customers.Add(new CustomerEntity()
                {
                   Id = customerModel.Id,
                   Name = customerModel.Name,
                   Email = customerModel.Email,
                   Cpf = customerModel.Cpf,
                   PhoneNumber = customerModel.PhoneNumber,
                });
            }
            return customers;

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

        public  virtual CustomerEntity CreateCustomer(CustomerEntity customer)
        {
            var customerModel = new CustomerModel()
            {
                Name = customer.Name,
                Email = customer.Email,
                Cpf = customer.Cpf,
                PhoneNumber = customer.PhoneNumber
            };
           
            _context.Customers.Add(customerModel);
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
