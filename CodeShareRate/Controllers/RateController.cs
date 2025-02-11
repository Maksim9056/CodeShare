using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareRate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private readonly IRateService _IRateService;

        private readonly ILogger<RateController> _logger;

        public RateController(ILogger<RateController> logger,IRateService rateService)
        {
            _logger = logger;
            _IRateService = rateService;
        }

        [HttpGet("rate/all", Name = "GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {



                var Rate_list = await _IRateService.GetListRates();
                return Ok(Rate_list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
    }
}
