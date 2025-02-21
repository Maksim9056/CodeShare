using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public  interface IChanges_in_the_system
    {

       public Task<Changes_in_the_system> Create(Changes_in_the_system changes_In_The_System);

        public Task<List<Changes_in_the_system>> ListAll(int take, HashSet<long> loadedIds); 

    }
}
