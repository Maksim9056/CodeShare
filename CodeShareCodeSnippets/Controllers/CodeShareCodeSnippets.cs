using CodeShare_Library.Date;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareCodeSnippets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeShareCodeSnippets : ControllerBase
    {
        private readonly CodeShareDB _Database  ;

        private readonly ILogger<CodeShareCodeSnippets> _logger;

        public CodeShareCodeSnippets(ILogger<CodeShareCodeSnippets> logger, CodeShareDB Database)
        {
            _logger = logger;
            _Database = Database;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
