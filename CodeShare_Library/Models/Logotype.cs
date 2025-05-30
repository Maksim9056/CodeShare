﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class Logotype
    {
        [Key]
        public long LogotypeId { get; set; }

        public string Name_Logotype { get; set; }

        public long  ImageId {  get; set; }

        public bool Active { get; set; }

        public bool Inactive { get; set; }
        public bool Realtime { get; set; }

    }
}
