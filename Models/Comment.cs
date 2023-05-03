﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _335a1.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
    }
}
