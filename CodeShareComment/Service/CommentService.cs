using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;

namespace CodeShareComment.Service
{
    public class CommentService : ICommentService
    {

        public readonly CodeShareDB _CodeShareDB;
        //public CodeShareDB _CodeShareDB;
        public CommentService(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }

        public async Task<Comment> AddComment(Comment add_comment)
        {
            try
            {
                await _CodeShareDB.Comment.AddAsync(add_comment);
                await _CodeShareDB.SaveChangesAsync();
                Log.Information($"Create Comment Topic{add_comment.SnippetsId} Rating {add_comment.RatingId}"+" {@Comment} registered successfully", add_comment);

                return add_comment;

            }catch (Exception ex)
            {
                Log.Error(ex.Message + $"Comment Topic{add_comment.SnippetsId} Rating {add_comment.RatingId}"+" {@Comment}", add_comment);
                return new Comment();
            }
        }

        public async  Task<Comment> EditComment(Comment comment)
        {
            try
            {
                Comment Comment = await _CodeShareDB.Comment.FirstOrDefaultAsync(coment => coment.SnippetsId == comment.SnippetsId  && coment .CommentId == comment.CommentId);
                Comment.IsHidden = comment.IsHidden;

                //_CodeShareDB.Comment.Update(comment);

                await _CodeShareDB.SaveChangesAsync();

                Log.Information($"Get Comment Topic{Comment.SnippetsId} Rating {Comment.RatingId}" + " {@Comment} registered successfully", Comment);

                return Comment;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic{comment.SnippetsId} Rating");
                return new Comment();
            }
        }

        public async Task<Comment> GetComment(long Id_Topic)
        {
            try
            {
               var  Comment = await _CodeShareDB.Comment.FirstOrDefaultAsync(coment =>coment.SnippetsId == Id_Topic);

                Log.Information($"Get Comment Topic{Comment.SnippetsId} Rating {Comment.RatingId}" + " {@Comment} registered successfully", Comment);

                return Comment;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic{Id_Topic} Rating" );
                return new Comment();
            }
        }

        public async Task<List<Comment>> GetListComment(long Id_Topic, int skip, int take, HashSet<long> loadedIds)
        {
            try
            {
                //List < Comment > comments = new List<Comment>();
                //// Исключаем загруженные Id
                var Comment = await _CodeShareDB.Comment.Where(coment => coment.SnippetsId == Id_Topic && !loadedIds.Any(us => us == coment.CommentId)).Take(take).ToListAsync();

                //if (loadedIds.Count() > 0)
                //{
                //    var Commenr = await _CodeShareDB.Comment.Where(comment => comment.SnippetsId == Id_Topic && !loadedIds.Contains(comment.CommentId))
                //   .OrderByDescending(c => c.CreateAt) // Сортируем от новых к старым
                //   .Skip(skip)
                //    // Берем только нужное количество
                //    .ToListAsync();
                //    comments = Commenr;

                //}
                //else
                //{
                //    //var = $"{DateTime.Now}";
                //    var Commenr = await _CodeShareDB.Comment.Where(comment => comment.SnippetsId == Id_Topic)
                //    .OrderByDescending(c => c.CreateAt ).Skip(skip) // Сортируем от новых к старым
                //    .Take(take) // Берем только нужное количество
                //    .ToListAsync();
                //    comments = Commenr;
                //}
               // var query = _CodeShareDB.Comment
               //.Where(comment => comment.SnippetsId == Id_Topic && !loadedIds.Contains(comment.CommentId)) // Исключаем загруженные
               //.OrderByDescending(c => c.CreateAt) // Сортируем от новых к старым
               //.Skip(skip) // Пропускаем уже загруженные
               //.Take(take); // Берем только нужное количество
               // //!selectedProducts.Any(sp => sp.Id == p.Id)).Take(count).ToList()
               // var comments = await query.ToListAsync();
                Log.Information($"GetList  Comment Topic" + " {@long} registered successfully", Id_Topic);

                return Comment;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment list Comment Topic{Id_Topic} Rating");
                return new List<Comment>();
            }
        }
    }
}
