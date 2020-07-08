using Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValue("NEWID()");

            modelBuilder.Entity<ProtfolioItem>().Property(x => x.Id).HasDefaultValue("NEWID()");

            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    Avater = "529.jpg",
                    FullName = "ADDI Amine",
                    Profil = "Microsoft .NET"
                }
                );
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<ProtfolioItem> protfolioItems { get; set; }
    }
}