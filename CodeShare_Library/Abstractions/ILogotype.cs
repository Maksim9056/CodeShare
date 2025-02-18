using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface ILogotype
    {
        Task<Logotype> Create(Logotype logotype);

        Task<Logotype> Update(Logotype logotype);
        Task<Logotype> Update(Logotype logotype,bool Real);


        Task<Logotype> Delete(Logotype logotype);

        Task<List<Logotype>> GetList(int take, HashSet<long> loadedIds);
    }
}
