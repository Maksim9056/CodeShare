using CodeShare_Library.Abstractions;
using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Service
{
    public class CodeShareCodeSnippetsService : ICodeShareCodeSnippets
    {
        public  readonly HttpClient httpClient;
        public CodeShareCodeSnippetsService()
        {
            httpClient = new HttpClient();
        }

        public async Task<CodeSnippets> Create(CodeSnippets users)
        {
            return new CodeSnippets();
        }

        public async Task<CodeSnippets> Delete(CodeSnippets codeSnippets)
        {
            return new CodeSnippets();
        }

        public async Task<CodeSnippets> Edit(CodeSnippets codeSnippets)
        {
            return new CodeSnippets();
        }

        public async Task<CodeSnippets> GetCodeSnippets(long Id_user)
        {
            return new CodeSnippets();

        }

        public async  Task<CodeSnippets> Get_browse_CodeSnippets()
        {
            return new CodeSnippets();

        }
    }
}
