using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface IManagentUser
    {
       Task Registration(Users user);

       Task Update(Users user);

        Task Delete(Users user);


        Task<Users> GetUser(long Id);

        Task<Users> CheckUser(string Email, string Password);

    }
}
