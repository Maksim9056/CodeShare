using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface ICommentService
    {
        public Task<Comment> AddComment(Comment add_comment);

        public Task<Comment> GetComment(long Id_Topic);

        public Task<List<Comment>> GetListComment(long Id_Topic, int skip, int take, HashSet<long> loadedIds);

    }
}
//List<Comment>