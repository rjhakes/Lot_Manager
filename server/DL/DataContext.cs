using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DataContext : DbContext
    {
        public DataContext ( DbContextOptions options) : base(options)
        {

        }

        public DbSet<Lot> Lots { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lot>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Spot>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Reservation>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            //A User can have many reservations, but a reservation can only have one user
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reservations)
                .WithOne(r => r.User);
            //A Spot can have many reservations, but a reservation can only have one spot
            modelBuilder.Entity<Spot>()
                .HasMany(s => s.Reservation)
                .WithOne(r => r.Spot);
            //A Lot can have many spots, but a spot can only have one lot
            modelBuilder.Entity<Lot>()
                .HasMany(l => l.Spots)
                .WithOne(s => s.Lot);
        }
    }
    
}