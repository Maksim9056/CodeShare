using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeShare_Library.Service
{
    public class SettingService : ISettingService
    {
        public readonly string UrlSettingApi;
        public string url;
        public readonly HttpClient _httpClient; // HttpClient для отправки запросов
        HttpResponseMessage _response { get; set; }
        public SettingService(string urlSettingApi)
        {

            UrlSettingApi = urlSettingApi;
            _httpClient = new HttpClient();

        }


        public async Task<Setting> Update(Setting setting)
        {
            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlSettingApi}/Setting/edit";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);
                }

            
             var responseMessage = await httpClient.PutAsJsonAsync(url, setting);

            if (responseMessage.IsSuccessStatusCode)
            {
                var SetingAnswer = await responseMessage.Content.ReadFromJsonAsync<Setting > ();
                    setting = SetingAnswer;
            }

                               //_httpClient.BaseAddress = null;
                return setting;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Setting();
            }
        }

        public async Task<Setting> Get(long Id_Code_Share)
        {
            try
            {

                HttpClient httpClient = new HttpClient();

                url = $"{UrlSettingApi}/Setting/get{Id_Code_Share}";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);
                }
                Setting Setting_responseMessage = await httpClient.GetFromJsonAsync<Setting>(url);

                return Setting_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Setting();
            }
        }
    }
}
