using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareUsers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementUserController : ControllerBase 
    {
     
        private readonly ILogger<ManagementUserController> _logger;

        private readonly IManagentUser _managentUser;
        public ManagementUserController(ILogger<ManagementUserController> logger, IManagentUser managentUser)
        {
            _logger = logger;
            _managentUser = managentUser;
        }

        //public async Task Delete(Users user)
        //{

        //}

        [HttpPost]
        public async Task Registration(Users user)
        {
            await     _managentUser.Registration(user);
        }

        //public async  Task Update(Users user)
        //{

        //}




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
