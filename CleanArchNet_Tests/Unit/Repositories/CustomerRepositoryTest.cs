using CleanArch_Domain.Customer.Repositories;
using CleanArch_Infrastructure.Database.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_Domain.Customer.Entities;
using NuGet.Frameworks;

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
                Password = "1234",
                Cpf = "431.528.448-65555532223222222222222255",
                PhoneNumber = "(19)9113328370-322222222222228165"
            });
            Assert.True(customer != null);

        }



    }
}
