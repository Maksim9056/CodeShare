using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using CodeShareRoles.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeShareRoles.Services
{
    public class RolesProvider : IRolesProvider
    {
        private readonly CodeShareDB _Database;
        public RolesProvider(CodeShareDB Database)
        {
            _Database = Database;
        }

        public async Task<IEnumerable<Roles>> GetAlll()
        {

            var rolles = _Database.Roles.ToList();
         
            if (rolles == null)
            {
                return Enumerable.Empty<Roles>();
            }
            return rolles;

        }

        public async Task<Roles> GetUser()
        {

            var rolles = await _Database.Roles.FirstOrDefaultAsync(u => u.RolesId == 2);
            if (rolles == null)
            {
                return new Roles() { };
            }
            return rolles;

        }
        public async Task<Roles> GetAdmin()
        {

            var rolles = await _Database.Roles.FirstOrDefaultAsync(u => u.RolesId == 1);
            if (rolles == null)
            {
                return new Roles() { };
            }
            return rolles;

        }
    }
}
