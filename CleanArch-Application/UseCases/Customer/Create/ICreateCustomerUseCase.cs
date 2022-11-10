using CleanArch_Application.UseCases._shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases.Customer.Create
{
    public interface ICreateCustomerUseCase: IUseCaseBase<InputCreateCustomerDTO, OutputCreateCustomerDTO>
    {
    }
}
