using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TechartMap_back.DAL.Models
{
    public class City
    {
        [Key]
      
        public int Id { get; set; }

        [Required]
        
        public string Name { get; set; }
        public ICollection<Cinema> Cinemas { get; set; }
        public City()
        {
            Cinemas=new List<Cinema>();
        }
    }
}
