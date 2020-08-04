using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechartMap_back.DAL.Models
{
    public class Film
    {
        public Film()
        {
            Sessions = new List<Session>();
        }

        [Key] public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Genre { get; set; }
        public int AgeLimit { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}