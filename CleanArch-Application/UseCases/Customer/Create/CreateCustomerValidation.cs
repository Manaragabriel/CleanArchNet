using CleanArch_Application.UseCases._shared;
using CleanArch_Domain._shared;
using CleanArch_Domain.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CleanArch_Application.UseCases.Customer.Create
{
    internal class CreateCustomerValidation
    {
        public static ValidationResult<IEnumerable<Notification>> Validate(CustomerEntity customer)
        {
            var notifications = new List<Notification>();
            if (customer.Email == "teste@teste.com")
            {
                string[] messages = {"E-mail já existe"};
                notifications.Add(new Notification("email", messages));

            }
            if (customer.PhoneNumber.Length < 11)
            {
                string[] messages = { "Digite um telefone válido" };
                notifications.Add(new Notification("phone", messages));

            }
            return new ValidationResult<IEnumerable<Notification>>(notifications.Count == 0, notifications);
        }
        
    }
}
