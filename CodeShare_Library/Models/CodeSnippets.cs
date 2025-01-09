using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class CodeSnippets
    {
        [Key]
        public long CodeSnippetsId { get; set; }

        public string Title { get; set; }
        public string Code { get; set; }

        public int  UserId { get; set; }
        public string Description { get; set; }

        public int IsAdmin { get; set; }

        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }

        public string Programming_language { get; set; }

    }
}
