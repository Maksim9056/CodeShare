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
    public class FilesService : IFilesService
    {
        public readonly string UrlFilesServiceApi;
        public string url = "";
        private readonly HttpClient _httpClient = new HttpClient();
        public FilesService(string urlFilesServiceApi)
        {
            UrlFilesServiceApi = urlFilesServiceApi;

        }
        public async Task<Image> Create(Image Id)
        {
            try
            {


                url = $"{UrlFilesServiceApi}/Files/create";
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
                var content = new StringContent(JsonSerializer.Serialize(Id), Encoding.UTF8, "application/json");

                var _response = await httpClient.PostAsync(url, content);

                //_response = await _httpClient.PostAsync(url, content);
                if (_response.IsSuccessStatusCode)
                {
                    Image Image = await _response.Content.ReadFromJsonAsync<Image>();
                    return Image;
                }
                return new Image() ;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new Image() ;

            }            
        }

        public Task<Image> Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> Get(Users Id)
        {
            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlFilesServiceApi}/Files/getall/get{Id.UsersId}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }

                Image Image_responseMessage = await httpClient.GetFromJsonAsync<Image>(url);
                return Image_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Image();
            }
        }

        public Task<Image> Get(int take, HashSet<long> loadedIds)
        {
            //try
            //{


            //    List<CodeSnippets> CodeSnippets_responseMessage = new List<CodeSnippets>();
            //    HttpClient httpClient = new HttpClient();
            //    url = $"{UrlCodeSnippetsApi}/CodeShareCodeSnippets/getall/get/{take}";
            //    if (httpClient.BaseAddress == null)
            //    {
            //        httpClient.BaseAddress = new Uri(url);

            //    }
            //    else
            //    {
            //        httpClient.BaseAddress = new Uri(url);

            //    }
            //    var responseMessage = await httpClient.PutAsJsonAsync(url, loadedIds);

            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        var CodeSnippets = await responseMessage.Content.ReadFromJsonAsync<List<CodeSnippets>>();
            //        CodeSnippets_responseMessage = CodeSnippets.ToList();
            //    }
            //    //_httpClient.BaseAddress = null;
            //    return CodeSnippets_responseMessage;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return new List<CodeSnippets>();
            //}
            throw new NotImplementedException();
        }

        public async Task<Image> Update(Image Id)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                url = $"{UrlFilesServiceApi}/Files/edit";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                var responseMessage = await httpClient.PutAsJsonAsync(url, Id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var CodeSnippets = await responseMessage.Content.ReadFromJsonAsync<Image>();
                    Id = CodeSnippets;
                }
                //_httpClient.BaseAddress = null;
                return Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return  Id;
            }
        }

        public Task<Image> Update(Image Id, bool Logo)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetLogotype(long Id_Logotype)
        {

            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlFilesServiceApi}/Files/getall/get/logotype{Id_Logotype}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }

                Image Image_responseMessage = await httpClient.GetFromJsonAsync<Image>(url);
                return Image_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Image();
            }
        }
    }
}
