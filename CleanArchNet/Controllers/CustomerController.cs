using CleanArch_Infrastructure.Database.Context;
using CleanArch_Application.UseCases.Customer.Find;
using CleanArch_Application.UseCases.Customer.Create;
using CleanArch_Domain.Customer.Entities;
using CleanArch_Infrastructure.Database.Customer.Repositories;
using CleanArch_Domain.Customer.Repositories;
using Microsoft.AspNetCore.Mvc;
using CleanArch_Domain._shared;
using CleanArch_Application.UseCases._shared;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchNet.Controllers
{
    [ApiController]
    [Route("/customer")]
    public class CustomerController

    {
        private ICreateCustomerUseCase createCustomerUseCase;
        private ICustomerRepository customerRepository;
        

        public CustomerController(ICreateCustomerUseCase createCustomerUseCase, ICustomerRepository customerRepository)
        {
            this.createCustomerUseCase = createCustomerUseCase;
            this.customerRepository = customerRepository;
        }
        [Authorize]
        [HttpGet]
        public AcceptedResult FindCustomers()
        {
            var customers = customerRepository.FindCustomers();
            return new AcceptedResult("", customers);
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] InputCreateCustomerDTO inputCreateCustomerDTO)
        {
            DefaultOutput<OutputCreateCustomerDTO> output =  createCustomerUseCase.execute(inputCreateCustomerDTO);
            if(!output.Success)
            {
                return new UnprocessableEntityObjectResult(output.Notifications);

            }
            return new CreatedResult("", output);

        } 


    }
}
