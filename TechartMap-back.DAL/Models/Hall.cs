using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechartMap_back.DAL.Models
{
    public class Hall
    {
        public Hall()
        {
            Rows = new List<Row>();
            Sessions = new List<Session>();
        }

        [Key] public int Id { get; set; }

        [Required] public int Number { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public ICollection<Row> Rows { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}