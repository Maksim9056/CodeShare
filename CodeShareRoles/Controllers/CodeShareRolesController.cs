using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeShareRoles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeShareRolesController : ControllerBase
    {
        private readonly ILogger<CodeShareRolesController> _logger;

        private readonly IRolesProvider _IRolesProvider;

        public CodeShareRolesController(ILogger<CodeShareRolesController> logger, IRolesProvider IRolesProvider)
        {
            _logger = logger;
            _IRolesProvider = IRolesProvider;
        }

        [HttpGet("roles/all", Name = "GetAllRoles")]
        public async Task<IEnumerable<Roles>> GetAlll()
        {
            return await _IRolesProvider.GetAlll();
        }

        [HttpGet("roles/user", Name = "GetUserRoles")]
        public async Task<Roles> GetUser()
        {
            return await _IRolesProvider.GetUser();
        }

        [HttpGet("roles/admin", Name = "GetAdminRoles")]
        public async Task<Roles> GetAdmin()
        {
            return await _IRolesProvider.GetAdmin();
        }
    }
}