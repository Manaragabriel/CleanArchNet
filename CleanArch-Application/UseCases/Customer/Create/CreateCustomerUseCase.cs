using CleanArch_Application.UseCases._shared;
using CleanArch_Domain._shared;
using CleanArch_Domain.Customer.Entities;
using CleanArch_Domain.Customer.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases.Customer.Create
{
    public class CreateCustomerUseCase: ICreateCustomerUseCase
    {

        private ICustomerRepository _customerRepository;

        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public DefaultOutput<OutputCreateCustomerDTO> execute(InputCreateCustomerDTO createCustomerDTO)
        {
            var customerEntity = CustomerMappers.InputCreateCustomerToEntity(createCustomerDTO);
            if (customerEntity.Email == "teste@teste.com")

            {
                var errors = new List<Notification>();
                string[] messages = { "E-mail ja existe" };
                errors.Add(new Notification( "email",messages));
                return new DefaultOutput<OutputCreateCustomerDTO>() { 
                    Message = "Unprocessable Entity",
                    Success = false,
                    Notifications = errors
                };
            }
          
            var newCustomer = _customerRepository.CreateCustomer(customerEntity);
            var output = new OutputCreateCustomerDTO()
            {

                Name = newCustomer.Name,
                Email = newCustomer.Email,
                Phone = newCustomer.PhoneNumber,
                Cpf = newCustomer.Cpf,
            };

            return new DefaultOutput<OutputCreateCustomerDTO>()
            {
                Message = "Created",
                Success = true,
                Result = output
            };
        }
    }
}
