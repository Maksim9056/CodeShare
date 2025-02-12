using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareSetting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController : ControllerBase
    {
  

        private readonly ILogger<SettingController> _logger;
        private readonly ISettingService _setingService;
       public SettingController(ILogger<SettingController> logger, ISettingService settingService)
        {
            _logger = logger;
            _setingService = settingService;
        }
        [HttpGet("get{Id_Topic}")]
        public async Task<IActionResult> GetSnippets(long Id_Topic)
        {
            return Ok(await _setingService.Get(Id_Topic));
        }

        [HttpPut("edit")]
        public async Task<Setting> EditCodeSnippets(Setting codeSnippets)
        {
            return await _setingService.Update(codeSnippets);
        }
    }
}
