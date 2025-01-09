using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class Changes_in_the_system
    {
        [Key]
        public long Changes_in_the_systemId { get; set; }


        public  string Text_update { get; set; }

        public string Action_Type { get; set; }

        public long UserId { get; set; }
        public string  CreateAt { get; set; }

    }
}
