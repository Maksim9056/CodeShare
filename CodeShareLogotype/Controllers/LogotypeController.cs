using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareLogotype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogotypeController : ControllerBase
    {

        private readonly ILogger<LogotypeController> _logger;
        private readonly ILogotype ILogotype;

        public LogotypeController(ILogger<LogotypeController> logger, ILogotype iLogotype)
        {
            _logger = logger;
            ILogotype = iLogotype;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create_Logotype(Logotype Logotype)
        {

            var comment = await ILogotype.Create(Logotype);

            return Ok(comment);
        }

        [HttpPut("getall/get/{take}")]
        public async Task<IActionResult> GetSnippetsAll([FromBody] HashSet<long> loaded, int take = 5)
        {
            return Ok(await ILogotype.GetList(take, loaded));
        }


        [HttpPut("edit/{real}")]
        public async Task<IActionResult> EditLogotype_active([FromBody] Logotype image ,bool real =true)
        {
            return Ok(await ILogotype.Update(image,real));
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditLogotype(Logotype image)
        {
            return Ok(await ILogotype.Update(image));
        }
    }
}
