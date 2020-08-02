using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechartMap_back.DAL.Models
{
   public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Genre { get; set; }
        public int AgeLimit { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public Film()
        {
            Sessions = new List<Session>();
        }
    }
}
