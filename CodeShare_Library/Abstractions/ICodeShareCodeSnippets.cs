using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface ICodeShareCodeSnippets
    { 
        Task<CodeSnippets> Create(CodeSnippets codeSnippets);
        Task<CodeSnippets> Edit(CodeSnippets codeSnippets);

        Task<CodeSnippets> Delete(CodeSnippets codeSnippets);

        Task<CodeSnippets> GetCodeSnippets(long Id_user);

        Task<CodeSnippets> Get_browse_CodeSnippets();

    }
}
