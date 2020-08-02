﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TechartMap_back.DAL.Models
{
    public class BannedUser
    {
        [Key]
        [ForeignKey("User")]
        public string Login { get; set; }

        [Required]
        public string Reason { get; set; }
        [Required]
        public DateTime BanDate { get; set; }

        [Required]
        public int Period { get; set; }
        public User User { get; set; }
    }
}
