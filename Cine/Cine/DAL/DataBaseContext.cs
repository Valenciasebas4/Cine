﻿using Cine.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cine.DAL
{
    public class DataBaseContext : DbContext
    {
        // Constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        #region Properties
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; } 
        public DbSet<Seat> Seats { get; set; }

        #endregion


        //Vamos a crear un índice para la tabla Countries
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Classification>().HasIndex(c => c.ClassificationName).IsUnique();
            modelBuilder.Entity<Gender>().HasIndex(g => g.GenderName).IsUnique();
            modelBuilder.Entity<Room>().HasIndex(r => r.NumberRoom).IsUnique();
            //modelBuilder.Entity<Seat>().HasIndex(s => s.NumberSeat).IsUnique();
            modelBuilder.Entity<Movie>().HasIndex(m => m.Title).IsUnique();
            modelBuilder.Entity<Seat>().HasIndex("NumberSeat", "RoomId").IsUnique(); // Para estos casos, debo crear un índice Compuesto
            modelBuilder.Entity<Hour>()
            .HasIndex(ms => new { ms.MovieId, ms.StarTime, ms.Date })
        .   IsUnique();
            modelBuilder.Entity<Movie>()
           .HasMany(m => m.Hours)
           .WithOne(h => h.Movie)
           .HasForeignKey(h => h.MovieId);



        }

    }
}
