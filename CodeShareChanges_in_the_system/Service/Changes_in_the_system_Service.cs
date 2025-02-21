using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CodeShareChanges_in_the_system.Service
{
    public class Changes_in_the_system_Service : IChanges_in_the_system
    {
        public readonly CodeShareDB _CodeShareDB;

        public Changes_in_the_system_Service(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }


        public async Task<Changes_in_the_system> Create(Changes_in_the_system changes_In_The_System)
        {
            try
            {
                await _CodeShareDB.Changes_in_the_system.AddAsync(changes_In_The_System);
                await _CodeShareDB.SaveChangesAsync();
                Log.Information($"Create Changes_in_the_system Topic{changes_In_The_System.Changes_in_the_systemId}   {changes_In_The_System.Text_update}" + " {@Changes_in_the_system} registered successfully", changes_In_The_System);

                return changes_In_The_System;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"Comment " + " {@Changes_in_the_system}", changes_In_The_System);
                return new Changes_in_the_system();
            }
        }

        public async Task<List<Changes_in_the_system>> ListAll(int take, HashSet<long> loadedIds)
        {
            try
            {
                //List < Comment > comments = new List<Comment>();
                //// Исключаем загруженные Id
                var changes_In_The_Systems = await _CodeShareDB.Changes_in_the_system.Where(coment => !loadedIds.Any(us => us == coment.Changes_in_the_systemId)).Take(take).ToListAsync();

                Log.Information($"GetList  Comment Topic" + " {@Changes_in_the_system} registered successfully", changes_In_The_Systems);

                return changes_In_The_Systems;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"ListAll list List<Changes_in_the_system Rating");
                return new List<Changes_in_the_system>();
            }

        }
    }
}
