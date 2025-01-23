using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{       

    public class UserService : IUserServise
    {

        public readonly string UrlUsersApi;

        public UserService(string urlUsersApi ) 
        {
          
            UrlUsersApi = urlUsersApi;


        }


        public async Task CreateUser(Users users)
        {

        }

        public async Task UpdateUser(Users users)
        {

        }


        public async Task DeletyUser(Users users)
        {

        }

        public async Task GetUser(long Id)
        {
        }

        public async Task CheckUser(string Email, string Password)
        {

        }
    }
}
