using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        public async Task<IActionResult> Registration(Users user)
        {
            try
            {


                //Log.Information($"Registration endpoint called with user:{@User}", user);

                await _managentUser.Registration(user);
                Log.Information("Registration User {@User} registered successfully", user);

                return Ok(user);
            }catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    


        [HttpGet]
        public async Task<Users> CheckUser([FromQuery]  string Email, [FromQuery] string Password)
        {

            return await _managentUser.CheckUser(Email, Password);
        }

        [HttpGet("users/Id{userId}", Name = "GetByIdAsync")]
        public async Task<Users> GetUsersId(long userId)
        {

            return await _managentUser.GetUser(userId);
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
