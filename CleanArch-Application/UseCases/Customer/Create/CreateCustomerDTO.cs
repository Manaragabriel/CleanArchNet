using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases.Customer.Create
{
    public class InputCreateCustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


    }
    public class OutputCreateCustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


    }
}
