using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechartMap_back.DAL.Models
{
    public class Hall
    { [Key] 
        public int Id { get; set; }
        [Required]
        public  int Number { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public ICollection<Row> Rows { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public Hall()
        {
            Rows = new List<Row>();
            Sessions=new List<Session>();
        }
    }
}
