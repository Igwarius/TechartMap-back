using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechartMap_back.DAL.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public int RowId { get; set; }
        public Row Row { get; set; }
    }
}
