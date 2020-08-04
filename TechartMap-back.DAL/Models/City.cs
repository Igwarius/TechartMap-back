using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechartMap_back.DAL.Models
{
    public class City
    {
        public City()
        {
            Cinemas = new List<Cinema>();
        }

        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        public ICollection<Cinema> Cinemas { get; set; }
    }
}