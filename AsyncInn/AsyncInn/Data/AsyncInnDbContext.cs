using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Async Inn Seattle",
                    StreetAddress = "123 Downtown Avenue South",
                    City = "Seattle",
                    State = "Washington",
                    Phone = "425-123-4567"
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 2,
                    Name = "Async Inn Bellevue",
                    StreetAddress = "456 Town Avenue",
                    City = "Bellevue",
                    State = "Washington",
                    Phone = "425-321-7654"
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 3,
                    Name = "Async Inn Redmond",
                    StreetAddress = "789 Main Street",
                    City = "Bellevue",
                    State = "Washington",
                    Phone = "425-351-4565"
                });
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Slumber City",
                    Layout = "Three Queen-sized beds"
                });
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 2,
                    Name = "RGB Room",
                    Layout = "Every wall is red, green, or blue"
                });
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 3,
                    Name = "Spa Experience",
                    Layout = "Two hot tubs"
                });
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 1,
                    Name = "Double-size Refrigerator"
                });
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 2,
                    Name = "Walk-in Shower"
                });
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 3,
                    Name = "Microwave Oven"
                });
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }
}
