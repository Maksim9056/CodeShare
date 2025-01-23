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
        Task CreateUser(Users users);
        Task UpdateUser(Users users);
        Task DeletyUser(Users users);

        Task GetUser(long Id);

        Task CheckUser(string Email,string Password);
    }
}
