using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VikiCarWash.Domain.Entities;
using VikiCarWash.Domain.Enums;

namespace VikiCarWash.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private int? _currentUserId;
        private UserRole? _currentUserRole;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CarWashBooking> CarWashBookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OtpVerification> OtpVerifications { get; set; }
        public DbSet<CarWashCenter> CarWashCenters { get; set; }

        /// <summary>
        /// Sets the current user context for query filters.
        /// MUST be called before queries to enforce data isolation.
        /// </summary>
        public void SetCurrentUser(int userId, UserRole userRole)
        {
            _currentUserId = userId;
            _currentUserRole = userRole;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== RELATIONSHIP CONFIGURATIONS =====
            modelBuilder.Entity<CarWashBooking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<CarWashBooking>()
                .HasOne(b => b.Center)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CenterId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<CarWashCenter>()
                .HasOne(c => c.Owner)
                .WithMany()
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<CarWashBooking>()
                .Property(b => b.Price)
                .HasPrecision(10, 2);

            // ===== QUERY FILTERS (Automatic Data Isolation) =====
            // Owners can only see bookings for centers they own
            modelBuilder.Entity<CarWashBooking>()
                .HasQueryFilter(b => 
                    _currentUserRole == UserRole.Admin ||  // Admins see all
                    (_currentUserRole == UserRole.Owner && b.Center.OwnerId == _currentUserId) ||  // Owners see their centers' bookings
                    (_currentUserRole == UserRole.Customer && b.CustomerId == _currentUserId)  // Customers see their own bookings
                );
        }
    }

}