﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectRefresh.Data;

#nullable disable

namespace ProjectRefresh.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241114015308_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectRefresh.Models.MsCar", b =>
                {
                    b.Property<string>("Car_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("license_plate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("model")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("number_of_car_seats")
                        .HasColumnType("int");

                    b.Property<decimal?>("price_per_day")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.Property<string>("transmission")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("year")
                        .HasColumnType("int");

                    b.HasKey("Car_id");

                    b.ToTable("MsCar");
                });

            modelBuilder.Entity("ProjectRefresh.Models.MsCarImages", b =>
                {
                    b.Property<string>("Image_car_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Car_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("image_link")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Image_car_id");

                    b.HasIndex("Car_id");

                    b.ToTable("MsCarImages");
                });

            modelBuilder.Entity("ProjectRefresh.Models.MsCustomer", b =>
                {
                    b.Property<string>("Customer_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("driver_license_number")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone_number")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Customer_id");

                    b.ToTable("MsCustomer");
                });

            modelBuilder.Entity("ProjectRefresh.Models.MsEmployee", b =>
                {
                    b.Property<string>("Employee_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("position")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Employee_id");

                    b.ToTable("MsEmployees");
                });

            modelBuilder.Entity("ProjectRefresh.Models.TrMaintenance", b =>
                {
                    b.Property<int>("Maintenance_id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Maintenance_id"), 1L, 1);

                    b.Property<string>("Car_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Employee_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<decimal?>("cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("description")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime?>("maintenance_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Maintenance_id");

                    b.HasIndex("Car_id");

                    b.HasIndex("Employee_id");

                    b.ToTable("TrMaintenances");
                });

            modelBuilder.Entity("ProjectRefresh.Models.TrPayment", b =>
                {
                    b.Property<string>("Payment_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Rental_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<double?>("amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("payment_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("payment_method")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Payment_id");

                    b.HasIndex("Rental_id");

                    b.ToTable("TrPayments");
                });

            modelBuilder.Entity("ProjectRefresh.Models.TrRental", b =>
                {
                    b.Property<string>("Rental_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Car_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Customer_id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool?>("payment_status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("rental_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("return_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("total_price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Rental_id");

                    b.HasIndex("Car_id");

                    b.HasIndex("Customer_id");

                    b.ToTable("TrRental");
                });

            modelBuilder.Entity("ProjectRefresh.Models.MsCarImages", b =>
                {
                    b.HasOne("ProjectRefresh.Models.MsCar", "MsCar")
                        .WithMany("MsCarImages")
                        .HasForeignKey("Car_id");

                    b.Navigation("MsCar");
                });

            modelBuilder.Entity("ProjectRefresh.Models.TrMaintenance", b =>
                {
                    b.HasOne("ProjectRefresh.Models.MsCar", "MsCar")
                        .WithMany("TrMaintenances")
                        .HasForeignKey("Car_id");

                    b.HasOne("ProjectRefresh.Models.MsEmployee", "MsEmployee")
                        .WithMany("TrMaintenances")
                        .HasForeignKey("Employee_id");

                    b.Navigation("MsCar");

                    b.Navigation("MsEmployee");
                });

            modelBuilder.Entity("ProjectRefresh.Models.TrPayment", b =>
                {
                    b.HasOne("ProjectRefresh.Models.TrRental", "TrRental")
                        .WithMany("TrPayments")
                        .HasForeignKey("Rental_id");

                    b.Navigation("TrRental");
                });

            modelBuilder.Entity("ProjectRefresh.Models.TrRental", b =>
                {
                    b.HasOne("ProjectRefresh.Models.MsCar", "MsCar")
                        .WithMany("TrRentals")
                        .HasForeignKey("Car_id");

                    b.HasOne("ProjectRefresh.Models.MsCustomer", "MsCustomer")
                        .WithMany("TrRentals")
                        .HasForeignKey("Customer_id");

                    b.Navigation("MsCar");

                    b.Navigation("MsCustomer");
                });

            modelBuilder.Entity("ProjectRefresh.Models.MsCar", b =>
                {
                    b.Navigation("MsCarImages");

                    b.Navigation("TrMaintenances");

                    b.Navigation("TrRentals");
                });

            modelBuilder.Entity("ProjectRefresh.Models.MsCustomer", b =>
                {
                    b.Navigation("TrRentals");
                });

            modelBuilder.Entity("ProjectRefresh.Models.MsEmployee", b =>
                {
                    b.Navigation("TrMaintenances");
                });

            modelBuilder.Entity("ProjectRefresh.Models.TrRental", b =>
                {
                    b.Navigation("TrPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
