using CleanArch_Domain.Customer.Entities;
using CleanArch_Domain.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases.Customer.Create
{
    public class CreateCustomerUseCase
    {

        private ICustomerRepository _customerRepository;

        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public OutputCreateCustomerDTO execute(InputCreateCustomerDTO createCustomerDTO)
        {
            var customerEntity = CustomerMappers.InputCreateCustomerToEntity(createCustomerDTO);
            var newCustomer = _customerRepository.CreateCustomer(customerEntity);

            return new OutputCreateCustomerDTO()
            {

                Name = newCustomer.Name,
                Email = newCustomer.Email,
                Phone = newCustomer.PhoneNumber,
                Cpf = newCustomer.Cpf,
            };
        }
    }
}
