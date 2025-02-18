using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;

namespace CodeShareCodeSnippets.Services
{
    public class CodeShareCodeSnippetsService : ICodeShareCodeSnippets
    {
        public readonly CodeShareDB _CodeShareDB;
        //public CodeShareDB _CodeShareDB;
        public CodeShareCodeSnippetsService(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }
        public async Task<CodeSnippets> Create(CodeSnippets  codeSnippets)
        {
            try
            {


                await _CodeShareDB.CodeSnippets.AddAsync(codeSnippets);
                await _CodeShareDB.SaveChangesAsync();
                Setting setting = new Setting() { SettingId = 0, SnippetId = codeSnippets.CodeSnippetsId, Visibility_Setting = codeSnippets.Description, Block = false, Hide = "", Prohibition = false };
                await _CodeShareDB.Setting.AddAsync(setting);
                await _CodeShareDB.SaveChangesAsync();

                return codeSnippets;
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return new CodeSnippets();
            }
        }

        public async Task<CodeSnippets> Edit(CodeSnippets codeSnippets)
        {
            _CodeShareDB.CodeSnippets.Update(codeSnippets);
            await _CodeShareDB.SaveChangesAsync();


            return new CodeSnippets() { };
        }

        public async Task<CodeSnippets> Delete(long codeSnippets)
        {
            var codeSnippet = await _CodeShareDB.CodeSnippets.FirstOrDefaultAsync(u => u.CodeSnippetsId == codeSnippets);

          
            _CodeShareDB.CodeSnippets.Remove(codeSnippet);


            
            await _CodeShareDB.SaveChangesAsync();
            return new CodeSnippets() { };
        }

        public async Task<CodeSnippets> GetCodeSnippets(long Id_user)
        {
            try
            {


                var codeSnippet = await _CodeShareDB.CodeSnippets.FirstOrDefaultAsync(u => u.CodeSnippetsId == Id_user);

                return codeSnippet;
            }
            catch(Exception ex) 
            {
                return new CodeSnippets() { };
            }
        }

        public Task<CodeSnippets> Get_browse_CodeSnippets()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CodeSnippets>> GetAllCodeSnippets(long Id_user)
        {
            var Code = await _CodeShareDB.CodeSnippets.Where(U=>U.UserId == Id_user).ToListAsync();
            Parallel.ForEach(Code, codeShare =>
            {
                codeShare.Code = "" ;

            });
            return Code;
        }

        //public async Task<List<CodeSnippets>> GetAllCodeSnippets(HashSet<long> loaded, int take = 5)
        //{
        //    var Code = await _CodeShareDB.CodeSnippets.ToListAsync();
        //    Parallel.ForEach(Code, codeShare =>
        //    {
        //        codeShare.Code = "";

        //    });
        //    return Code;
        //}

        public async Task<List<CodeSnippets>> GetAllCodeSnippets(int take, HashSet<long> loadedIds)
        {
            try
            {
                var Code = await _CodeShareDB.CodeSnippets.Where(coment =>!loadedIds.Any(us => us == coment.CodeSnippetsId)).Take(take).ToListAsync();
                List < CodeSnippets > Filter = new List<CodeSnippets >();
                foreach (var code in Code)
                {
                    var setting = await _CodeShareDB.Setting.FirstOrDefaultAsync(U => U.SnippetId == code.CodeSnippetsId);

                    if(setting.Visibility_Setting == "Private")
                    {

                    }
                    else
                    {
                        Filter.Add(code);
                    }
                }
                Code.Clear();
                Log.Information("{@CodeSnippet}  successfully", Code);
                return Filter;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return  new List<CodeSnippets>();
            }
        }
    }
}
