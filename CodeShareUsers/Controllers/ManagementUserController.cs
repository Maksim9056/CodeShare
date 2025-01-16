using Microsoft.AspNetCore.Mvc;

namespace CodeShareUsers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementUserController : ControllerBase
    {
     
        private readonly ILogger<ManagementUserController> _logger;

        public ManagementUserController(ILogger<ManagementUserController> logger)
        {
            _logger = logger;
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
