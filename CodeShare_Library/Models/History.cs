using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class History
    {
        [Key]
        public long HistoryId { get; set; }


        public string Change_date { get; set; }

        public long SnippetId { get; set; }
        public string Year { get; set; }

    }
}
