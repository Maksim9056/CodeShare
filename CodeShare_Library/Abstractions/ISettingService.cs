using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface ISettingService
    {
        Task<Setting> Get(long  Id_Code_Share);

        Task<Setting> Update(Setting setting);
    }
}
