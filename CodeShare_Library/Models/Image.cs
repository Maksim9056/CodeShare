using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class Image
    {
        [Key]
        public long ImageId { get; set; }

        public string ImageDate { get; set; }

        public long? LogotypeId { get; set; }

        public long? UserId { get; set; }

        public string CreateAt { get; set; }

        
    }
}
