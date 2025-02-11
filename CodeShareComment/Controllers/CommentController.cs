using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeShareComment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
   

        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;
        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateCodeSnippets(Comment comment_add)
        {
            
           var comment  = await _commentService.AddComment(comment_add);

            return Ok(comment);
        }


        //[HttpPut("edit")]
        //public async Task<CodeSnippets> EditCodeSnippets(CodeSnippets codeSnippets)
        //{
        //    return await _commentService.Edit(codeSnippets);
        //}


        //[HttpDelete("delete")]
        //public async Task<CodeSnippets> DeleteCodeSnippets(CodeSnippets codeSnippets)
        //{
        //    return await _commentService.Delete(codeSnippets);
        //}



        [HttpPut("getall/get{Id_Topic}/{skip}/{take}")]
        public async Task<IActionResult> GetSnippetsAll([FromBody] HashSet<long> loaded ,long Id_Topic, int skip = 0, int take = 5)
        {
            return Ok(await _commentService.GetListComment(Id_Topic, skip,take, loaded));
        }


        [HttpGet("get{Id_Topic}")]
        public async Task<IActionResult> GetSnippets(long Id_Topic)
        {
            return Ok(await _commentService.GetComment(Id_Topic));
        }

    }
}
