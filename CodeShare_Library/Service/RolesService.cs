using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{
    public class RolesService : IRolesProvider
    {
        public readonly string UrlRolesApi;
        public string url;
        public readonly HttpClient _httpClient; // HttpClient для отправки запросов
        HttpResponseMessage _response { get; set; }
        public RolesService(string urlRolesApi)
        {

            UrlRolesApi = urlRolesApi;
            _httpClient = new HttpClient();

        }

        //public RolesService(string urlRolesApi, HttpClient httpClient)
        //{

        //    UrlRolesApi = urlRolesApi;
        //    _httpClient = httpClient;

        //}

        public async Task<Roles> GetAdmin()
        {
            try
            {

                return new Roles() { };
            }
            catch (Exception ex)
            {
                return new Roles() { };

            }
        }

        public async Task<IEnumerable<Roles>> GetAlll()
        {

            url = $"{UrlRolesApi}/CodeShareRoles/roles/all";
            _httpClient.BaseAddress = new Uri(url);
            List<Roles> Roles_responseMessage = await _httpClient.GetFromJsonAsync<List<Roles>>(url);
            return Roles_responseMessage;
        }

        public async Task<Roles> GetUser()
        {
            try
            {

                url = $"{UrlRolesApi}/CodeShareRoles/roles/user";
                _httpClient.BaseAddress = new Uri(url);
                Roles Roles_responseMessage =  await  _httpClient.GetFromJsonAsync<Roles>(url);
                //_response.EnsureSuccessStatusCode();
                //var jsonResponse =await  _response.Content.ReadAsStringAsync();
                ////  /CodeShareRoles/roles/user
                return Roles_responseMessage;
            }
            catch (Exception ex)
            {
                return new Roles() { };

            }
        }
    }
}
