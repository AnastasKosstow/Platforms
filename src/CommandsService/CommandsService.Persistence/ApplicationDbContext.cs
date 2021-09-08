using Microsoft.EntityFrameworkCore;
using CommandsService.Persistence.Models;

namespace CommandsService.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region DbSets
        
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }
    }
}
