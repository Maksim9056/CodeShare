using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface IFilesService
    {
        Task<Image> Get(Users Id);
        Task<Image> Get(int take, HashSet<long> loadedIds);
        Task<Image> GetLogotype(long Id_Logotype);

        Task<Image> Create(Image Id);
        Task<Image> Update(Image Id);
        Task<Image> Update(Image Id,bool Logo);

        Task<Image> Delete(long Id);

    }
}
