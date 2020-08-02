using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechartMap_back.DAL.Models
{
   public class Row
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public int Number { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Place> Places { get; set; }
        public Row()
        {
            Places = new List<Place>();
        }
    }
}
