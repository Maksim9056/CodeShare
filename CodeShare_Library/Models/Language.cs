using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class Language
    {
        [Key]
        public long Id_Programming_language { get; set; }

        public string Programming_language { get; set; }
    }
}
