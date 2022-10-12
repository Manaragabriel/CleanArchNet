using CleanArch_Domain.Customer.Repositories;
using CleanArch_Infrastructure.Database.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_Domain.Customer.Entities;
using NuGet.Frameworks;
using System.ComponentModel.DataAnnotations;

namespace CleanArchNet_Tests.Unit.Repositories
{
    [Collection("Customers repository tests")]

    public class CustomerRepositoryTest
    {
        private ICustomerRepository _customerRepository;

        public CustomerRepositoryTest()
        {
            _customerRepository = new CustomerRepository();
        }
                
        [Fact]
        public void testCreateCustomer()
        {
            var customer = _customerRepository.CreateCustomer(new CustomerClass()
            {
                Name = "Teste nome",
                Email = "test@teste.com",
                Cpf = "431.528.448-65555532223222222222222255",
                PhoneNumber = "(19)9113328370-322222222222228165"
            });
            Assert.True(customer != null);
        }

        [Fact]
        public void GivenAnUserAndUpdate()
        {
            var customerToUpdate = _customerRepository.FindCustomer("test@teste.com");
            var customer = _customerRepository.UpdateCustomer(new CustomerClass()
            {
                Id = customerToUpdate.Id,
                Email = "test@teste.com",
                Name = "editado again",
                Cpf = "431.528.333-22",
                PhoneNumber = "(19)12345-6789"
            });
            Assert.False(customer.Equals(customerToUpdate));
        }

    }
}
