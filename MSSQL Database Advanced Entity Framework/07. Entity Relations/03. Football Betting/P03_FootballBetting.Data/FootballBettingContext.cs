using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(Configuration configuration)
        {
            Configuration = configuration;
        }

        public FootballBettingContext(DbContextOptions<FootballBettingContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public Configuration Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Configuration.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity => { entity.HasKey(e => e.ColorId); });
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.HasOne(e => e.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(e => e.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.SecondaryKitColor)
                    .WithMany(e => e.SecondaryKitTeams)
                    .HasForeignKey(e => e.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Town)
                    .WithMany(e => e.Teams)
                    .HasForeignKey(e => e.TownId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.AwayGames)
                    .WithOne(e => e.AwayTeam)
                    .HasForeignKey(e => e.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.HomeGames)
                    .WithOne(e => e.HomeTeam)
                    .HasForeignKey(e => e.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.HasOne(e => e.Team)
                    .WithMany(e => e.Players)
                    .HasForeignKey(e => e.TeamId);

                entity.HasOne(e => e.Position)
                    .WithMany(e => e.Players)
                    .HasForeignKey(e => e.PositionId);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);

                entity.HasMany(e => e.Teams)
                    .WithOne(e => e.Town)
                    .HasForeignKey(e => e.TownId);

                entity.HasOne(e => e.Country)
                    .WithMany(e => e.Towns)
                    .HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId);

                entity.HasOne(e => e.Game)
                    .WithMany(e => e.Bets)
                    .HasForeignKey(e => e.GameId);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Bets)
                    .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<User>(entity => { entity.HasKey(e => e.UserId); });

            modelBuilder.Entity<Country>(entity => { entity.HasKey(e => e.CountryId); });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.HasMany(e => e.PlayerStatistics)
                    .WithOne(e => e.Game)
                    .HasForeignKey(e => e.GameId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.HasMany(e => e.Players)
                    .WithOne(e => e.Position)
                    .HasForeignKey(e => e.PositionId);
            });
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new {e.GameId, e.PlayerId});

                entity.HasOne(e => e.Player)
                    .WithMany(e => e.PlayerStatistics)
                    .HasForeignKey(e => e.PlayerId);
            });
        }
    }
}