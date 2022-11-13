using CleanArch_Application.UseCases.Customer.Create;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace CleanArchNet_Tests.Integration
{
    
    public  class CustomerTest
    {
        private HttpClient client;
        public CustomerTest()
        {
            var webAppFactory = new TestApplicationClass();
            this.client = webAppFactory.CreateClient();

        }

        [Fact]
        public async Task CreateCustomer_ShouldCreateACustomer()
        {
            var input = new InputCreateCustomerDTO() {
                Name = "Teste nome",
                Email = "test@teste.com",
                Cpf = "431.528.448-65",
                Phone = "(19)11111-1111"
            };
            var json = JsonConvert.SerializeObject(input);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/customer", stringContent);
            Assert.True(response.StatusCode == HttpStatusCode.Created);

        }
    }
}
