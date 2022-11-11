using CleanArch_Infrastructure.Database.Context;
using CleanArch_Application.UseCases.Customer.Find;
using CleanArch_Application.UseCases.Customer.Create;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchNet.Controllers
{
    [ApiController]
    [Route("/customer")]
    public class CustomerController

    {
        private ICreateCustomerUseCase createCustomerUseCase;
        public CustomerController(ICreateCustomerUseCase createCustomerUseCase)
        {
            this.createCustomerUseCase = createCustomerUseCase;
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] InputCreateCustomerDTO inputCreateCustomerDTO)
        {
            var newCustomer =  createCustomerUseCase.execute(inputCreateCustomerDTO);

            return new CreatedResult("", newCustomer);

        }


    }
}
