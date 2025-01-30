using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{
    public class LanguageServise : ILanguage
    {
        public readonly string UrlRolesApi;
        public string url;
        public readonly HttpClient _httpClient; // HttpClient для отправки запросов
        public LanguageServise(string urlRolesApi)
        {
            UrlRolesApi = urlRolesApi;
           _httpClient = new HttpClient();

        }

        public async Task<Language> CreateAsync(Language language)
        {
            url = $"{UrlRolesApi}/CodeShareRoles/roles/all";
            _httpClient.BaseAddress = new Uri(url);
            Language Roles_responseMessage = await _httpClient.GetFromJsonAsync<Language>(url);

            return language;

        }

        public async Task<bool> DeleteAsync(long id)
        {
            url = $"{UrlRolesApi}/CodeShareRoles/roles/all";
            _httpClient.BaseAddress = new Uri(url);
            bool Roles_responseMessage = await _httpClient.GetFromJsonAsync<bool>(url);



            return Roles_responseMessage;

        }

        public async Task<List<Language>> GetAllAsync()
        {

            url = $"{UrlRolesApi}/Language/language/all";
            _httpClient.BaseAddress = new Uri(url);
            List<Language> Roles_responseMessage = await _httpClient.GetFromJsonAsync< List<Language>>(url);

            return Roles_responseMessage;

        }

        public async Task<Language> GetByIdAsync(long id)
        {
            url = $"{UrlRolesApi}/CodeShareRoles/roles/all{id}";
            _httpClient.BaseAddress = new Uri(url);
            Language Roles_responseMessage = await _httpClient.GetFromJsonAsync<Language>(url);

            return Roles_responseMessage;

        }

        public async  Task<Language> UpdateAsync(Language language)
        {
            url = $"{UrlRolesApi}/CodeShareRoles/roles/all";
            _httpClient.BaseAddress = new Uri(url);
            Language Roles_responseMessage = await _httpClient.GetFromJsonAsync<Language>(url);

            return Roles_responseMessage;
        }
    }
}
