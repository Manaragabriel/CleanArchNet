using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_Domain.Customer.Entities;

namespace CleanArch_Domain.Customer.Repositories
{
    public interface ICustomerRepository
    {
         CustomerClass FindCustomer(string email);

         CustomerClass CreateCustomer(CustomerClass customer);

        CustomerClass UpdateCustomer(CustomerClass customer);
        
    }
}
