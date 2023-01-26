using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MediEval.Hubs;

namespace MediEval.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy_Medicine>().HasKey(pm => new
            {
                pm.Pharmacy_ID,
                pm.Medicine_ID
            });

            modelBuilder.Entity<Pharmacy_Medicine>().HasOne(p => p.pharmacy).WithMany(pm => pm.pharmacy_medicine).HasForeignKey(m => m.Pharmacy_ID);
            modelBuilder.Entity<Pharmacy_Medicine>().HasOne(m=>m.medicine).WithMany(pm => pm.pharmacy_medicine).HasForeignKey(p => p.Medicine_ID);

            base.OnModelCreating(modelBuilder);//Pass the Model Builder to the base class. (Important for Default Authentication Tables)

        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Pharmacy_Medicine> Pharmacy_Medicines { get; set; }

        public DbSet<PharmacyBrand> PharmaBrands { get; set; }

        public DbSet<Order> Orders { get; set; }
        //Orders related tables
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
