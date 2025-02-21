using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareChanges_in_the_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Changes_in_the_systemController : ControllerBase
    {
    
        private readonly ILogger<Changes_in_the_systemController> _logger;
        
        private readonly IChanges_in_the_system IChanges_in_the_system;

        public Changes_in_the_systemController(ILogger<Changes_in_the_systemController> logger,IChanges_in_the_system changes_In_The_System)
        {
            _logger = logger;
            IChanges_in_the_system = changes_In_The_System;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateCodeSnippets(Changes_in_the_system Image)
        {

            var comment = await IChanges_in_the_system.Create(Image);

            return Ok(comment);
        }

        [HttpPut("getall/get/{take}")]
        public async Task<IActionResult> GetSnippetsAll([FromBody] HashSet<long> loaded, int take = 5)
        {
            return Ok(await IChanges_in_the_system.ListAll(take, loaded));
        }
    }
}
