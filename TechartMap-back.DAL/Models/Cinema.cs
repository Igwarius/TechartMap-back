using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechartMap_back.DAL.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Hall> Halls { get; set; }
        public Cinema()
        {
            Halls = new List<Hall>();
        }
    }
}
