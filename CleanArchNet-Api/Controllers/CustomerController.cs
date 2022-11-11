using CleanArch_Application.UseCases.Customer.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchNet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult<OutputCreateCustomerDTO> CreateCustomer([FromBody] InputCreateCustomerDTO inputCreateCustomerDTO)
        {
            var newCustomer = createCustomerUseCase.execute(inputCreateCustomerDTO);

            return new C

        }
    }
}
