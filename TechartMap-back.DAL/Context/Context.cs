using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.DAL.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BannedUser> BannedUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}