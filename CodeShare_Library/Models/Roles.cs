﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Models
{
    public class Roles
    {
        [Key]
        public long RolesId { get; set; }

        public string NameRole { get; set; }
    }
}
