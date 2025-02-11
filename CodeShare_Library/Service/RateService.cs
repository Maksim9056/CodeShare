using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{
    public class RateService : IRateService
    {
        public readonly string UrlRateServiceApi;
        public string url = "";
        private readonly HttpClient _httpClient = new HttpClient();
        public RateService(string urlUrlRateServiceApi)
        {
            UrlRateServiceApi = urlUrlRateServiceApi;

        }
        public async Task<List<Rate>> GetListRates()
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                url = $"{UrlRateServiceApi}/Rate/rate/all";
                if (httpClient.BaseAddress == null)
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                else
                {
                    httpClient.BaseAddress = new Uri(url);

                }
                List<Rate> Rate_responseMessage = await httpClient.GetFromJsonAsync<List<Rate>>(url);

                return Rate_responseMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Rate>();
            }
        }

        public async Task<Rate> GetRate()
        {
            return new Rate();

        }
    }
}
