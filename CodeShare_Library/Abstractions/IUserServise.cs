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
        Task UpdateUser(Users users);
        Task DeletyUser(Users users);

        Task GetUser(long Id);

        Task<Users> CheckUser(string Email,string Password);
    }
}
