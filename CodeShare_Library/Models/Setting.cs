using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class Setting
    {
        [Key]
        public long SettingId { get; set; }
        public string Visibility_Setting { get; set; }

        public string Hide { get; set; }
        public bool Prohibition { get; set; }
        public bool Block { get; set; }

        public  long SnippetId { get; set; }


    }
}
