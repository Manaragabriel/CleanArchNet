using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Infrastructure.Database.Customer.Entities
{
    public  class CustomerModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        
        [MaxLength(255)]
        
        public string Email { get; set; }


        [MaxLength(14)]

        public string PhoneNumber { get; set; }

        [MaxLength(14)]

        public string Cpf { get; set; }

    }
}
