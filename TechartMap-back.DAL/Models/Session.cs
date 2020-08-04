using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechartMap_back.DAL.Models
{
    public class Session
    {
        public Session()
        {
            Transactions = new List<Transaction>();
        }

        [Key] public int Id { get; set; }

        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}