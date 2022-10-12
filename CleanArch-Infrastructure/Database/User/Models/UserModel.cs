using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Infrastructure.Database.User.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }


        [MaxLength(255)]
        public string Email { get; set; }


        [MaxLength(255)]
        public string Password { get; set; }

        
        public bool IsActive { get; set; }
    }
}
