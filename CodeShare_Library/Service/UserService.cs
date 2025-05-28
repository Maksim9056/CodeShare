using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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
            _httpClient.BaseAddress=new Uri(UrlUsersApi);
        } 

        public async Task<Users> CreateUser(Users users)
        {
            //url=$"{UrlUsersApi}/ManagementUser";
            var content = new StringContent(JsonSerializer.Serialize(users), Encoding.UTF8, "application/json");

            _response =   await  _httpClient.PostAsync("/ManagementUser", content);
            if (_response.IsSuccessStatusCode)
            {
                 Users Users = await  _response.Content.ReadFromJsonAsync<Users>();
                return Users;
            }
            //_response.EnsureSuccessStatusCode();
            return new Users(){Email="" };
        }

        public async Task<Users> UpdateUser(Users users)
        {
            try
            {
                
                //url = $"{UrlUsersApi}/ManagementUser/edit";
                HttpClient httpClient = new HttpClient();
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                //var responseMessage = await httpClient.PutAsJsonAsync(url, users);
                var responseMessage = await _httpClient.PutAsJsonAsync("/ManagementUser/edit", users);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var User_Answer = await responseMessage.Content.ReadFromJsonAsync<Users>();
                    users = User_Answer;
                }


                return users;
            }
            catch (Exception ex)
            {
                return new Users() { };
            }
        }


        public async Task<Users> DeletyUser(Users users)
        {
            try
            {

                url = $"{UrlUsersApi}/ManagementUser/delete{users.UsersId}";
                HttpClient httpClient = new HttpClient();
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }

                var responseMessage = await httpClient.DeleteAsync(url);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var User_Answer = await responseMessage.Content.ReadFromJsonAsync<Users>();
                    users = User_Answer;
                }


                return users;
            }
            catch (Exception ex)
            {
                return new Users() { };
            }
        }

        public async Task<Users> GetUser(long Id)
        {
            try
            {

                url = $"{UrlUsersApi}/ManagementUser/users/Id{Id}";
                HttpClient httpClient = new HttpClient();

                if (httpClient.BaseAddress == null)
                {

                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                Users Users_responseMessage = await httpClient.GetFromJsonAsync<Users>(url);

                return Users_responseMessage;


            }
            catch (Exception ex)
            {
                return new Users() { };
            }

        }

        public async Task<Users> CheckUser(string Email, string Password)
        {
            try
            {


                url = $"{UrlUsersApi}/ManagementUser?Email={Email}&Password={Password}";
                //_httpClient.BaseAddress = new Uri(url);
                HttpClient httpClient = new HttpClient();

                if (httpClient.BaseAddress == null)
                {

                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                Users Roles_responseMessage = await httpClient.GetFromJsonAsync<Users>(url);
                return Roles_responseMessage;

            }
            catch (Exception ex) 
            {
                return new Users() { };
            }
        }
    }
}
