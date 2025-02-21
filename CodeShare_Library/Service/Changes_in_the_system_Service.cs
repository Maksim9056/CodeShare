using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{
    public class Changes_in_the_system_Service : IChanges_in_the_system
    {
        public readonly string UrlChanges_in_the_system_Api;
        public string url = "";
        private readonly HttpClient _httpClient = new HttpClient();
        public Changes_in_the_system_Service(string urChanges_in_the_system_Api)
        {
            UrlChanges_in_the_system_Api = urChanges_in_the_system_Api;
            //_httpClient = new HttpClient();

        }


        public async Task<Changes_in_the_system> Create(Changes_in_the_system changes_In_The_System)
        {
            try
            {


                url = $"{UrlChanges_in_the_system_Api}/Changes_in_the_system/create";
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
                var content = new StringContent(JsonSerializer.Serialize(changes_In_The_System), Encoding.UTF8, "application/json");

                var _response = await httpClient.PostAsync(url, content);

                //_response = await _httpClient.PostAsync(url, content);
                if (_response.IsSuccessStatusCode)
                {
                    Changes_in_the_system Changes_in_the_system = await _response.Content.ReadFromJsonAsync<Changes_in_the_system>();
                    return Changes_in_the_system;
                }
                return new Changes_in_the_system();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new Changes_in_the_system() { UserId = 0 };

            }
        }

        public async Task<List<Changes_in_the_system>> ListAll(int take, HashSet<long> loadedIds)
        {
            try
            {


                List<Changes_in_the_system> CodeSnippets_responseMessage = new List<Changes_in_the_system>();
                HttpClient httpClient = new HttpClient();
                url = $"{UrlChanges_in_the_system_Api}/Changes_in_the_system/getall/get/{take}";
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
                    var CodeSnippets = await responseMessage.Content.ReadFromJsonAsync<List<Changes_in_the_system>>();
                    CodeSnippets_responseMessage = CodeSnippets;
                }
                //_httpClient.BaseAddress = null;
                return CodeSnippets_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Changes_in_the_system>();
            }
        }
    }
}
