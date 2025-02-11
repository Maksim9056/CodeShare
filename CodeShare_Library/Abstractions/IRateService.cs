using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface IRateService
    {
        public  Task<Rate> GetRate() ;
        public Task<List<Rate>> GetListRates();

    }
}
