using CleanArch_Application.UseCases.Customer.Create;
using CleanArch_Domain.Customer.Entities;
using CleanArch_Domain.Customer.Repositories;
using CleanArch_Infrastructure.Database.Customer.Repositories;
using Moq;
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

        [Fact]
        public void test()
        {
            var mockObj = new Mock<CustomerEntity>();
            var mockRepo = new Mock<ICustomerRepository>();
            mockRepo.Setup(mock => mock.CreateCustomer(It.IsAny<CustomerEntity>())).Returns(mockObj.Object);
            var _createCustomerUseCase = new CreateCustomerUseCase(mockRepo.Object);

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
