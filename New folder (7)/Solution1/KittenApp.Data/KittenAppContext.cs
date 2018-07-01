using System;
using System.Collections.Generic;
using System.Text;
using KittenApp.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using KittenApp.Models;

namespace KittenApp.Data
{
    public class KittenAppContext :DbContext
    {
        public KittenAppContext()
        {
        }

        public KittenAppContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Kitten> Kittens { get; set; }

        public DbSet<Kitten> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KittenConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
