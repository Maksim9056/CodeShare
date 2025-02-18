using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareFiles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService IFilesService;
        private readonly ILogger<FilesController> _logger;

        public FilesController(ILogger<FilesController> logger, IFilesService FilesService)
        {
            _logger = logger;
            IFilesService = FilesService;

        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCodeSnippets(Image Image)
        {

            var comment = await IFilesService.Create(Image);
            comment.ImageDate = "";
            return Ok(comment);
        }

        [HttpGet("getall/get{UserID}")]
        public async Task<IActionResult> GetSnippetsAll(long UserID)
        {
            Users User = new Users() { UsersId = UserID };
            return Ok(await IFilesService.Get(User));
        }

        [HttpGet("getall/get/logotype{logotype_Id}")]
        public async Task<IActionResult> GetlogotypeImageAll(long logotype_Id)
        {

                return Ok(await IFilesService.GetLogotype(logotype_Id));
        }
        [HttpPut("edit")]
        public async Task<IActionResult> EditCodeSnippets(Image image)
        {
            if(image.LogotypeId != null)
            {
                image = await IFilesService.Update(image,true);

            }
            else
            {
                image= await IFilesService.Update(image);

            }

            return Ok(image);
        }



    }
}
