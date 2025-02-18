using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface IUserServise
    {
        Task<Users> CreateUser(Users users);
        Task<Users> UpdateUser(Users users);
        Task<Users> DeletyUser(Users users);

        Task<Users> GetUser(long Id);

        Task<Users> CheckUser(string Email,string Password);
    }
}
