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
using Moq;
using CleanArch_Infrastructure.Database.Customer.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArch_Infrastructure.Database.Context;
using System.Net.Sockets;

namespace CleanArchNet_Tests.Unit.Repositories
{
    [Collection("Customers repository tests")]

    public class CustomerRepositoryTest
    {

            
        [Fact]
        public void CreateCustomer_ShouldCreateAnCustomer()
        {
            var mockDbSet = new Mock<DbSet<CustomerModel>>();
            var mockContext = new Mock<MainDbContext>();
            mockContext.Setup(mock => mock.Customers).Returns(mockDbSet.Object);
            var customerRepo = new CustomerRepository(mockContext.Object);

            var customer = new CustomerEntity()
            {
                Name = "Teste nome",
                Email = "test@teste.com",
                Cpf = "431.528.448-65",
                PhoneNumber = "(19)11111-1111"
            };
            var newCustomer = customerRepo.CreateCustomer(customer);
            mockDbSet.Verify(m => m.Add(It.IsAny<CustomerModel>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

     

    }
}
