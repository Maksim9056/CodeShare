using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{
    internal class Changes_in_the_system_Service : IChanges_in_the_system
    {
        public Task<Changes_in_the_system> Create(Changes_in_the_system changes_In_The_System)
        {
            throw new NotImplementedException();
        }

        public Task<List<Changes_in_the_system>> ListAll(int take, HashSet<long> loadedIds)
        {
            throw new NotImplementedException();
        }
    }
}
