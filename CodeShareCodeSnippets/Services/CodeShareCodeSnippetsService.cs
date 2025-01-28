using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeShareCodeSnippets.Services
{
    public class CodeShareCodeSnippetsService : ICodeShareCodeSnippets
    {
        public readonly CodeShareDB codeShareDB;
        public CodeShareDB _CodeShareDB;
        public CodeShareCodeSnippetsService(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }
        public async Task<CodeSnippets> Create(CodeSnippets  codeSnippets)
        {
            await _CodeShareDB.CodeSnippets.AddAsync(codeSnippets);
            await _CodeShareDB.SaveChangesAsync();
            return new CodeSnippets() { };
        }

        public async Task<CodeSnippets> Edit(CodeSnippets codeSnippets)
        {
            _CodeShareDB.CodeSnippets.Update(codeSnippets);
            await _CodeShareDB.SaveChangesAsync();


            return new CodeSnippets() { };
        }

        public async Task<CodeSnippets> Delete(CodeSnippets codeSnippets)
        {
            var codeSnippet = await _CodeShareDB.CodeSnippets.FirstOrDefaultAsync(u => u.CodeSnippetsId == codeSnippets.CodeSnippetsId);


            _CodeShareDB.CodeSnippets.Remove(codeSnippet);


            
            await _CodeShareDB.SaveChangesAsync();
            return new CodeSnippets() { };
        }

        public Task<CodeSnippets> GetCodeSnippets(long Id_user)
        {
            throw new NotImplementedException();
        }

        public Task<CodeSnippets> Get_browse_CodeSnippets()
        {
            throw new NotImplementedException();
        }
    }
}
