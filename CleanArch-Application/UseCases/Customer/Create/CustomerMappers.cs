using CleanArch_Domain.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArch_Application.UseCases.Customer.Create
{
    internal class CustomerMappers
    {
        public static  CustomerClass InputCreateCustomerToEntity(InputCreateCustomerDTO inputCreateCustomerDTO)
        {
            return new CustomerClass()
            {
                Name = inputCreateCustomerDTO.Name,
                Email = inputCreateCustomerDTO.Email,
                Cpf = inputCreateCustomerDTO.Cpf,
                PhoneNumber = inputCreateCustomerDTO.Phone,

            };
        }
    }
}
