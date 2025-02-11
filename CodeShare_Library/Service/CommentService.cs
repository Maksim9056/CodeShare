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
    public class CommentService : ICommentService
    {
        public readonly string UrlCommentServiceApi;
        public string url = "";
        private readonly HttpClient _httpClient = new HttpClient();
        public CommentService(string urlCommentServiceApi)
        {
            UrlCommentServiceApi = urlCommentServiceApi;

        }
        public async Task<Comment> AddComment(Comment add_comment)
        {
            try
            {
                url = $"{UrlCommentServiceApi}/Comment/create";
             
                HttpClient httpClient = new HttpClient();

                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                var content = new StringContent(JsonSerializer.Serialize(add_comment), Encoding.UTF8, "application/json");

                var _response = await httpClient.PostAsync(url, content);

                if (_response.IsSuccessStatusCode)
                {
                    Comment CodeSnippets = await _response.Content.ReadFromJsonAsync<Comment>();
                    return CodeSnippets;
                }

                return new Comment();
            }
            catch (Exception ex)
            {
                return new Comment() { Comment_Text= "Error"};

            }
        }

        public async Task<Comment> GetComment(long Id_Topic)
        {
            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlCommentServiceApi}/Comment/get{Id_Topic}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }

                Comment Comment_responseMessage = await httpClient.GetFromJsonAsync<Comment>(url);
                //_httpClient.BaseAddress = null;
                return Comment_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Comment();
            }
        }

        public async Task<List<Comment>> GetListComment(long Id_Topic, int skip, int take, HashSet<long> loadedIds)
        {
            try
            {
                List<Comment> Comment_responseMessage = new List<Comment>();
                HttpClient httpClient = new HttpClient();
                url = $"{UrlCommentServiceApi}/Comment/getall/get{Id_Topic}/{skip}/{take}";
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
                    var comments= await responseMessage.Content.ReadFromJsonAsync<List<Comment>>();
                    Comment_responseMessage= comments.ToList();
                }

                //List<Comment> Roles_responseMessage = await httpClient.GetFromJsonAsync<List<Comment>>(url, loadedIds);
                //_httpClient.BaseAddress = null;
                return Comment_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Comment>();
            }
        }

        public async Task<Comment> EditComment(Comment comment)
        {
            try
            {
                Comment Comment_responseMessage = new Comment();
                HttpClient httpClient = new HttpClient();
                url = $"{UrlCommentServiceApi}/Comment/edit";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                var responseMessage = await httpClient.PutAsJsonAsync(url, comment);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var comments = await responseMessage.Content.ReadFromJsonAsync<Comment>();
                    Comment_responseMessage = comments;
                }

                //List<Comment> Roles_responseMessage = await httpClient.GetFromJsonAsync<List<Comment>>(url, loadedIds);
                //_httpClient.BaseAddress = null;
                return Comment_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Comment();
            }
        }
    }
}
