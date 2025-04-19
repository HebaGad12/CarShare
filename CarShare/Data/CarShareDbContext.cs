using CarShare.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Data
{
    internal class CarShareDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DFH\\MSSQLSERVER01;Database=CarShare;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Renter)
                .WithMany(r => r.Proposals)
                .HasForeignKey(p => p.RenterId)
                .OnDelete(DeleteBehavior.Restrict);

          
            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.CarPost)
                .WithMany(c => c.Proposals)
                .HasForeignKey(p => p.CarId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> AdminProfiles { get; set; }
        public DbSet<Owner> OwnerProfiles { get; set; }
        public DbSet<Renter> RenterProfiles { get; set; }
        public DbSet<CarPost> CarPosts { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<RentalContract> RentalContracts { get; set; }
    }
}
