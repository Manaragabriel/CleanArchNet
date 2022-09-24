using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases.Customer.Find
{
     public class InputFindCustomerDTO
    {
        public string Email { get; set; }
    }
    public class OutputFindCustomerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }

    }
}
