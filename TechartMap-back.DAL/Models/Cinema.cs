using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechartMap_back.DAL.Models
{
    public class Cinema
    {
        public Cinema()
        {
            Halls = new List<Hall>();
        }

        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Hall> Halls { get; set; }
    }
}