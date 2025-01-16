using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface IRolesProvider
    {
        public IEnumerable<Roles> GetAlll();
        public  Task<Roles> GetUser();

        public Task<Roles> GetAdmin();

    }
}
