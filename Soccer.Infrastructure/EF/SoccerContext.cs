using Microsoft.EntityFrameworkCore;
using Soccer.Domain.Entities;

namespace Soccer.Infrastructure.EF
{   
    public class SoccerContext : DbContext
    { 
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public SoccerContext(DbContextOptions<SoccerContext> options)
                   : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
