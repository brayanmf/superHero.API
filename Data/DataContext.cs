using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Data
{
    public class DataContext:DbContext//heradado de entityframework
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
      }
    
}
