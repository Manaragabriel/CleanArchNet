using CleanArch_Application.UseCases.Customer.Find;

namespace CleanArchNet_Tests
{
    [Collection("Customers tests")]
    public class UnitTest1
    {
        private FindCustomerUseCase _customerUseCase;

        public UnitTest1()
        {
            _customerUseCase = new FindCustomerUseCase();

        }
        [Fact]
        public void Test1()
        {

            var input = new InputFindCustomerDTO()
            {
                Email = "gabrielmanara2010@hotmail.com"
            };
            var customer = _customerUseCase.execute(input);
            Assert.True(customer != null);

        }
    }
}