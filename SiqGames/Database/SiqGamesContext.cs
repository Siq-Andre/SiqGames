using Microsoft.EntityFrameworkCore;
using SiqGames.Model;

namespace SiqGames.Database
{
    public class SiqGamesContext: DbContext
    {
        public SiqGamesContext(): base() { }

        public DbSet<Player> Player { get; set; }
        public DbSet<Studio> Studio { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
