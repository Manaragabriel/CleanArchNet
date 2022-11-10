using CleanArch_Application.UseCases.Customer.Create;
using CleanArch_Domain.Customer.Repositories;
using CleanArch_Infrastructure.Database.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchNet_Tests.Unit.UseCases.Customer
{
    [Collection("Create ")]

    public class CreateCustomerTest
    {
        private CreateCustomerUseCase _createCustomerUseCase;

        public CreateCustomerTest( )
        {
            CustomerRepository customerRepository = new CustomerRepository(new CleanArch_Infrastructure.Database.Context.MainDbContext());
            _createCustomerUseCase = new CreateCustomerUseCase(customerRepository);
        }

        [Fact]
        public void test()
        {
            var newCustomer = new InputCreateCustomerDTO()
            {
                Name = "Manara use case",
                Email = "usecase@test.com",
                Cpf = "111.111.111-11",
                Phone = "(11)11111-1111"
            };
            var customerCreated = _createCustomerUseCase.execute(newCustomer);
            Assert.True(customerCreated != null);
        }
    }
}
