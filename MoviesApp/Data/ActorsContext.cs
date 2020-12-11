using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class ActorsContext : DbContext
    {
        public ActorsContext(DbContextOptions<ActorsContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actor { get; set; }
    }
}