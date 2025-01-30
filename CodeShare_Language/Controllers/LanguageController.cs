using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShare_Language.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
       
        private readonly ILogger<LanguageController> _logger;
        public readonly ILanguage Language;
        public LanguageController(ILogger<LanguageController> logger, ILanguage language)
        {
            _logger = logger;
            Language = language;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Language language)
        {
            try
            {



                var Language_create = await Language.CreateAsync(language);
                return Ok(Language_create);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("language/all", Name = "GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {



                var Language_list = await Language.GetAllAsync();
                return Ok( Language_list);
            }
            catch (Exception ex)
            {
                return  BadRequest( ex.Message );
            }

        }

        [HttpGet("language/Id{id}", Name = "GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {



                var language = await Language.GetByIdAsync(id);
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("language/update", Name = "UpdateAsync")]

        public async Task<IActionResult> UpdateAsync(Language language)
        {
            try
            {



                 language = await Language.UpdateAsync(language);
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("language/delete{id}", Name = "DeleteAsync")]
        public async Task<IActionResult > DeleteAsync(long id)
        {
            try
            {


                //bool
              bool  language = await Language.DeleteAsync(id);
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
