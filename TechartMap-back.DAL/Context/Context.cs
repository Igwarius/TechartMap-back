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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}