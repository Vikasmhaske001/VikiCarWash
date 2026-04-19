using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VikiCarWash.Domain.Entities;

namespace VikiCarWash.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CarWashBooking>CarWashBookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OtpVerification> OtpVerifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarWashBooking>()
    .HasOne(b => b.Customer)
    .WithMany(c => c.Bookings)  // ← Map to the Bookings collection
    .HasForeignKey(b => b.CustomerId)
    .OnDelete(DeleteBehavior.Cascade);
        }
    }

}