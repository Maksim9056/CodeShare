using Azure;
using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{
    public class CodeShareCodeSnippetsService : ICodeShareCodeSnippets
    {
   
        public readonly string UrlCodeSnippetsApi;
        public string url = "";
        private readonly HttpClient _httpClient = new HttpClient();
        public CodeShareCodeSnippetsService(string urlCodeSnippetsApi)
        {
            UrlCodeSnippetsApi = urlCodeSnippetsApi;
            //_httpClient = new HttpClient();

        }

        public async Task<CodeSnippets> Create(CodeSnippets codeSnippets)
        {
            try
            {


                url = $"{UrlCodeSnippetsApi}/CodeShareCodeSnippets/create";
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
                var content = new StringContent(JsonSerializer.Serialize(codeSnippets), Encoding.UTF8, "application/json");

                var _response = await httpClient.PostAsync(url, content);

                //_response = await _httpClient.PostAsync(url, content);
                if (_response.IsSuccessStatusCode)
                {
                    CodeSnippets CodeSnippets = await _response.Content.ReadFromJsonAsync<CodeSnippets>();
                    return CodeSnippets;
                }
                return new CodeSnippets() { Title = "" };
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new CodeSnippets() { UserId=0};

            }
        }

        public async Task<CodeSnippets> Delete(long codeSnippets)
        {
            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlCodeSnippetsApi}/CodeShareCodeSnippets/delete/{codeSnippets}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                CodeSnippets delete_responseMessage = await httpClient.DeleteFromJsonAsync<CodeSnippets>(url);
                //_httpClient.BaseAddress = null;
                return delete_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CodeSnippets();
            }
        }

        public async Task<CodeSnippets> Edit(CodeSnippets codeSnippets)
        {
            return new CodeSnippets();
        }

        public async Task<List<CodeSnippets>> GetAllCodeSnippets(long Id_user)
        {
            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlCodeSnippetsApi}/CodeShareCodeSnippets/getall/get{Id_user}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                List<CodeSnippets> Roles_responseMessage = await httpClient.GetFromJsonAsync<List<CodeSnippets>>(url);
                //_httpClient.BaseAddress = null;
                return Roles_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CodeSnippets>();
            }
        }


        public async Task<List<CodeSnippets>> GetAllCodeSnippets(int take, HashSet<long> loadedIds)
        {
            try
            {


                List<CodeSnippets> CodeSnippets_responseMessage = new List<CodeSnippets>();
                HttpClient httpClient = new HttpClient();
                url = $"{UrlCodeSnippetsApi}/CodeShareCodeSnippets/getall/get/{take}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                var responseMessage = await httpClient.PutAsJsonAsync(url, loadedIds);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var CodeSnippets = await responseMessage.Content.ReadFromJsonAsync<List<CodeSnippets>>();
                    CodeSnippets_responseMessage = CodeSnippets.ToList();
                }
                //_httpClient.BaseAddress = null;
                return CodeSnippets_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CodeSnippets>();
            }
        }

        public async Task<CodeSnippets> GetCodeSnippets(long Id_user)
        {
            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlCodeSnippetsApi}/CodeShareCodeSnippets/get{Id_user}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                CodeSnippets Roles_responseMessage = await httpClient.GetFromJsonAsync<CodeSnippets>(url);
                //_httpClient.BaseAddress = null;
                return Roles_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CodeSnippets();
            }
        }

        public async  Task<CodeSnippets> Get_browse_CodeSnippets()
        {
            return new CodeSnippets();

        }
    }
}
