﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PricingCalculator.DataAccess;

#nullable disable

namespace PricingCalculator.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PricingCalculator.DataAccess.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FreeDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("ServiceStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PricingCalculator.DataAccess.Entities.CustomerService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("CustomerPrice")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CustomerServices");
                });

            modelBuilder.Entity("PricingCalculator.DataAccess.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<bool>("IsWorkingDayService")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("PricingCalculator.DataAccess.Entities.CustomerService", b =>
                {
                    b.HasOne("PricingCalculator.DataAccess.Entities.Customer", "Customer")
                        .WithMany("CustomerServices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PricingCalculator.DataAccess.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("PricingCalculator.DataAccess.Entities.Customer", b =>
                {
                    b.Navigation("CustomerServices");
                });
#pragma warning restore 612, 618
        }
    }
}
