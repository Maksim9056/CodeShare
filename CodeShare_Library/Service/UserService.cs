using Azure;
using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{       

    public class UserService : IUserServise
    {
        private readonly HttpClient _httpClient; // HttpClient для отправки запросов

        public readonly string UrlUsersApi;
        public string url;
        HttpResponseMessage _response;
        public UserService(string urlUsersApi ) 
        {
          
            UrlUsersApi = urlUsersApi;
            _httpClient = new HttpClient();


        } 
        public async Task<Users> CreateUser(Users users)
        {
            url=$"{UrlUsersApi}/ManagementUser";
            var content = new StringContent(JsonSerializer.Serialize(users), Encoding.UTF8, "application/json");

            _response =   await  _httpClient.PostAsync(url, content);
            if (_response.IsSuccessStatusCode)
            {
                 Users Users = await  _response.Content.ReadFromJsonAsync<Users>();
                return Users;
            }
            //_response.EnsureSuccessStatusCode();
            return new Users(){Email="" };
        }

        public async Task UpdateUser(Users users)
        {
             url = $"{UrlUsersApi}/ManagementUser";

        }


        public async Task DeletyUser(Users users)
        {
            url = $"{UrlUsersApi}/ManagementUser";


        }

        public async Task GetUser(long Id)
        {
            url = $"{UrlUsersApi}/ManagementUser";

        }

        public async Task<Users> CheckUser(string Email, string Password)
        {
            try
            {


                url = $"{UrlUsersApi}/ManagementUser?Email={Email}&Password={Password}";
                //_httpClient.BaseAddress = new Uri(url);
                Users Roles_responseMessage = await _httpClient.GetFromJsonAsync<Users>(url);
                return Roles_responseMessage;

            }
            catch (Exception ex) 
            {
                return new Users() { };
            }
        }
    }
}
