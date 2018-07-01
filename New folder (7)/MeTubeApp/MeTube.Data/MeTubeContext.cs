using MeTube.Data.EntityConfiguration;
using MeTube.Models;
using Microsoft.EntityFrameworkCore;

namespace MeTube.Data
{
    public class MeTubeContext: DbContext

    {
        public MeTubeContext()
        {
        }
        public MeTubeContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tube> Tubes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TubeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
