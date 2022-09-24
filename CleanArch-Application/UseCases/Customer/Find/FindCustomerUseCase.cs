using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_Domain.Customer.Entities;
using CleanArch_Domain.Customer.Repositories;
using CleanArch_Infrastructure.Database.Customer.Repositories;

namespace CleanArch_Application.UseCases.Customer.Find
{
    public class FindCustomerUseCase

    {
        private ICustomerRepository customerRepository;
        public FindCustomerUseCase()
        {
            this.customerRepository = new CustomerRepository();
        }
        public OutputFindCustomerDTO execute(InputFindCustomerDTO filter)
        {
            var customer = customerRepository.FindCustomer(filter.Email);

            return new OutputFindCustomerDTO()
            {
                Id = customer.Id,
                Email = customer.Email,
                Name = customer.Name,
                Cpf = customer.Cpf,
                Phone = customer.PhoneNumber
            };
        }
    }
}
