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
    public class LogotypeService : ILogotype
    {
        public readonly string UrlLogotypeServiceApi;
        public string url = "";
        private readonly HttpClient _httpClient = new HttpClient();
        public LogotypeService(string urlFLogotypeServiceApi)
        {
            UrlLogotypeServiceApi = urlFLogotypeServiceApi;

        }

        public async Task<Logotype> Create(Logotype logotype)
        {
            try
            {


                url = $"{UrlLogotypeServiceApi}/Logotype/create";
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
                var content = new StringContent(JsonSerializer.Serialize(logotype), Encoding.UTF8, "application/json");

                var _response = await httpClient.PostAsync(url, content);

                //_response = await _httpClient.PostAsync(url, content);
                if (_response.IsSuccessStatusCode)
                {
                    Logotype Logotype = await _response.Content.ReadFromJsonAsync<Logotype>();
                    return Logotype;
                }
                return new Logotype();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new Logotype();

            }
        }

        public Task<Logotype> Delete(Logotype logotype)
        {
            throw new NotImplementedException();
        }

        public async  Task<Logotype> Update(Logotype logotype)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                url = $"{UrlLogotypeServiceApi}/Logotype/edit";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                var responseMessage = await httpClient.PutAsJsonAsync(url, logotype);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var CodeSnippets = await responseMessage.Content.ReadFromJsonAsync<Logotype>();
                    logotype = CodeSnippets;
                }
                //_httpClient.BaseAddress = null;
                return logotype;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return logotype;
            }
        }




        public async Task<List<Logotype>> GetList(int take, HashSet<long> loadedIds)
        {
            try
            {
                List<Logotype> Comment_responseMessage = new List<Logotype>();
                HttpClient httpClient = new HttpClient();
                url = $"{UrlLogotypeServiceApi}/Logotype/getall/get/{take}";


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
                    var comments = await responseMessage.Content.ReadFromJsonAsync<List<Logotype>>();
                    Comment_responseMessage = comments;
                }

   
                return Comment_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Logotype>();
            }
        }

        public  async Task<Logotype> Update(Logotype logotype, bool Real)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                url = $"{UrlLogotypeServiceApi}/Logotype/edit/{Real}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                var responseMessage = await httpClient.PutAsJsonAsync(url, logotype);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var CodeSnippets = await responseMessage.Content.ReadFromJsonAsync<Logotype>();
                    logotype = CodeSnippets;
                }
                return logotype;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return logotype;
            }
        }
        public async Task<Logotype> Get()
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                

                url = $"{UrlLogotypeServiceApi}/Logotype/get/logotypeactive";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                Logotype Logotype_responseMessage = await httpClient.GetFromJsonAsync<Logotype>(url);
                //_httpClient.BaseAddress = null;
                return Logotype_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Logotype();
            }
        }
    }
}
