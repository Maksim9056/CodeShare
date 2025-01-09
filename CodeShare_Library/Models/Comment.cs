using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class Comment
    {
        [Key]
        public long CommentId { get; set; }

        public string Name_Comment { get; set; }
        public string Selected_Range { get; set; }

       public long RatingId {  get; set; }

        public int SnippetsId { get; set; }

        public long UserId { get; set; }

        public string CreateAt { get; set; }
        public string Comment_Text { get; set; }
    }
}
