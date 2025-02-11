using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareCodeSnippets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeShareCodeSnippets : ControllerBase
    {
        private readonly ICodeShareCodeSnippets _codeShareCodeSnippets  ;

        private readonly ILogger<CodeShareCodeSnippets> _logger;

        public CodeShareCodeSnippets(ILogger<CodeShareCodeSnippets> logger, ICodeShareCodeSnippets codeShareCodeSnippets)
        {
            _logger = logger;
            _codeShareCodeSnippets = codeShareCodeSnippets;
        }

        [HttpPost("create")]
        public async Task<CodeSnippets> CreateCodeSnippets(CodeSnippets codeSnippets)
        {
           return await _codeShareCodeSnippets.Create(codeSnippets);
        }


        [HttpPut("edit")]
        public async Task<CodeSnippets> EditCodeSnippets(CodeSnippets codeSnippets)
        {
           return await _codeShareCodeSnippets.Edit(codeSnippets);
        }


        [HttpDelete("delete")]
        public async Task<CodeSnippets> DeleteCodeSnippets(CodeSnippets codeSnippets)
        {
          return   await _codeShareCodeSnippets.Delete(codeSnippets);
        }



        [HttpGet("getall/get{codeSnippets}")]
        public async Task<IActionResult> GetSnippetsAll(long codeSnippets)
        {
            return Ok( await _codeShareCodeSnippets.GetAllCodeSnippets(codeSnippets));
        }


        [HttpPut("getall/get/{take}")]
        public async Task<IActionResult> GetSnippetsAll([FromBody] HashSet<long> loaded,int take = 5)
        {
            return Ok(await _codeShareCodeSnippets.GetAllCodeSnippets(take,loaded));
        }

        [HttpGet("get{codeSnippets}")]
        public async Task<IActionResult> GetSnippets(long codeSnippets)
        {
            return Ok(await _codeShareCodeSnippets.GetCodeSnippets(codeSnippets));
        }

        //[HttpGet]
        //public async Task<Users> CheckUser([FromQuery] string Email, [FromQuery] string Password)
        //{

        //    return await _managentUser.CheckUser(Email, Password);
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
