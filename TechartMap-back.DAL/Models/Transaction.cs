using System.ComponentModel.DataAnnotations;

namespace TechartMap_back.DAL.Models
{
    public class Transaction
    {
        [Key] public int Id { get; set; }

        public string TransactionType { get; set; }
        public int PlaceId { get; set; }
        public int Place { get; set; }
        public int Row { get; set; }
        public int Price { get; set; }
        public string UserLogin { get; set; }
        public User User { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}