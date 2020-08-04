using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechartMap_back.DAL.Models
{
    public class Row
    {
        public Row()
        {
            Places = new List<Place>();
        }

        [Key] public int Id { get; set; }

        [Required] public int Number { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}