using CleanArch_Domain.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Domain.User.Repositories
{
    public interface IUserRepository
    {
        public UserEntity CreateUser(UserEntity user);
    }
}
