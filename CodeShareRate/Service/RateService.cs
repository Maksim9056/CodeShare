using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeShareRate.Service
{
    public class RateService : IRateService
    {


        public CodeShareDB _CodeShareDB;
        public RateService(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }

        public async Task<List<Rate>> GetListRates()
        {
            try
            {
                var rates = await _CodeShareDB.Rate.ToListAsync();


                return rates;
            }
            catch (Exception ex)
            {
                return new List<Rate>();
            }
        }

        public async Task<Rate> GetRate()
        {
            return new Rate();
        }
    }
}
