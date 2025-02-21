using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CodeShareLogotype.Service
{
    public class LogotypeService : ILogotype
    {

        public readonly CodeShareDB _CodeShareDB;
        //public CodeShareDB _CodeShareDB;
        public LogotypeService(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }


        public async Task<Logotype> Create(Logotype logotype)
        {
            try
            {
                await _CodeShareDB.Logotype.AddAsync(logotype);

                //_CodeShareDB.Comment.Update(comment);

                await _CodeShareDB.SaveChangesAsync();

                Log.Information($"Get Create   Logotype {logotype.Name_Logotype} " + " {@Logotype} registered successfully", logotype);

                return logotype;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic Rating");
                return new Logotype();
            }
        }

        public Task<Logotype> Delete(Logotype logotype)
        {
            throw new NotImplementedException();
        }

        public async Task<Logotype> Get()
        {
            try
            {
                var logotypy = await _CodeShareDB.Logotype.FirstOrDefaultAsync(u => u.Active == true && u.Realtime == true);
                return logotypy;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic Rating");
                return new Logotype();
            }
        }

            public async Task<List<Logotype>> GetList(int take, HashSet<long> loadedIds)
        {
            try
            {

                var Logotype = await _CodeShareDB.Logotype.Where(coment => !loadedIds.Any(us => us == coment.LogotypeId)).Take(take).ToListAsync();
                return Logotype;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic Rating");
                return new List<Logotype>();
            }

        }

        public async Task<Logotype> Update(Logotype logotype)
        {
            try
            {
               var logotypes = await _CodeShareDB.Logotype.FirstOrDefaultAsync(u =>u.ImageId ==logotype.ImageId);
                logotypes.LogotypeId = logotype.LogotypeId;
                //_CodeShareDB.Comment.Update(comment);

                await _CodeShareDB.SaveChangesAsync();

                Log.Information($"Get Create   Logotype {logotypes.Name_Logotype} " + " {@Logotype} registered successfully", logotypes);

                return logotype;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic Rating");
                return new Logotype();
            }
        }

        public async Task<Logotype> Update(Logotype logotype, bool Real)
        {
            try
            {
                var logotyp = await _CodeShareDB.Logotype.FirstOrDefaultAsync(u => u.Active == true && u.Realtime == true);
                logotyp.Realtime = false;
                logotyp.Active = false;

                 await _CodeShareDB.SaveChangesAsync();
                var logotypes = await _CodeShareDB.Logotype.FirstOrDefaultAsync(u => u.LogotypeId == logotype.LogotypeId);
                logotypes.LogotypeId = logotype.LogotypeId;
                logotypes.Realtime = logotype.Realtime;
                logotypes.Name_Logotype = logotype.Name_Logotype;
                logotypes.Active = logotype.Active;
                logotypes.ImageId = logotype.ImageId;
                logotypes.Inactive = logotype.Inactive;
                await _CodeShareDB.SaveChangesAsync();

                //_CodeShareDB.Comment.Update(comment);
                Log.Information($"Get Update   Logotype {logotypes.Name_Logotype} " + " {@Logotype} registered successfully", logotypes);

                return logotype;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic Rating");
                return new Logotype();
            }
        }
    }
}
