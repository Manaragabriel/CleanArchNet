using CleanArch_Infrastructure.Database.Context;
using Microsoft.AspNetCore.Mvc;
using CleanArch_Application.UseCases.Customer.Find;

namespace CleanArchNet.Controllers
{
    [ApiController]
    [Route("/customer")]
    public class CustomerController

    {
       
        [HttpGet]
        public OutputFindCustomerDTO GetCustomers([FromQuery(Name = "email")] string email)
        {
            var input = new InputFindCustomerDTO() { Email = email};
            return new FindCustomerUseCase().execute(input);
        }
    }
}
