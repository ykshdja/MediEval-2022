﻿// <auto-generated />
using System;
using MediEval.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediEval.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MediEval.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicineID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<int>("MedicineCategory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("pharmaBrandId")
                        .HasColumnType("int");

                    b.Property<string>("weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicineID");

                    b.HasIndex("pharmaBrandId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MediEval.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<double>("OrderCost")
                        .HasColumnType("float");

                    b.Property<int?>("PrescriptionId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MediEval.Models.Pharmacy", b =>
                {
                    b.Property<int>("PharmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PharmID"), 1L, 1);

                    b.Property<string>("PharmAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PharmName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PharmPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PharmID");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("MediEval.Models.Pharmacy_Medicine", b =>
                {
                    b.Property<int>("Pharmacy_ID")
                        .HasColumnType("int");

                    b.Property<int>("Medicine_ID")
                        .HasColumnType("int");

                    b.HasKey("Pharmacy_ID", "Medicine_ID");

                    b.HasIndex("Medicine_ID");

                    b.ToTable("Pharmacy_Medicines");
                });

            modelBuilder.Entity("MediEval.Models.PharmacyBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PharmaBrands");
                });

            modelBuilder.Entity("MediEval.Models.Medicine", b =>
                {
                    b.HasOne("MediEval.Models.PharmacyBrand", "pharmaBrand")
                        .WithMany()
                        .HasForeignKey("pharmaBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pharmaBrand");
                });

            modelBuilder.Entity("MediEval.Models.Pharmacy_Medicine", b =>
                {
                    b.HasOne("MediEval.Models.Pharmacy", "pharmacy")
                        .WithMany("pharmacy_medicine")
                        .HasForeignKey("Medicine_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediEval.Models.Medicine", "medicine")
                        .WithMany("pharmacy_medicine")
                        .HasForeignKey("Pharmacy_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medicine");

                    b.Navigation("pharmacy");
                });

            modelBuilder.Entity("MediEval.Models.Medicine", b =>
                {
                    b.Navigation("pharmacy_medicine");
                });

            modelBuilder.Entity("MediEval.Models.Pharmacy", b =>
                {
                    b.Navigation("pharmacy_medicine");
                });
#pragma warning restore 612, 618
        }
    }
}
