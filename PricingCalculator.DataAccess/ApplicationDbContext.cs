﻿using Microsoft.EntityFrameworkCore;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<CustomerService> CustomerServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
       
        modelBuilder.Entity<Customer>().HasData(
             new Customer
             {
                 Id = new Guid("d7b2c1b1-84c3-4e51-ade6-d2ab5043ed15"),
                 FreeDays = 0
             },
             new Customer
             {
                 Id = new Guid("3aeb3a2f-0e8d-4b88-b33c-5bc15b68b98b"),
                 FreeDays = 200
             }
        );

        modelBuilder.Entity<Service>().HasData(
           new Service
           {
               Id = new Guid("5e162f58-1f6d-4db0-b59f-c82e50aa7b4b"),
               Name = "Service A",
               BasePrice = 0.2m,
               IsWorkingDayService = true,
           },
           new Service
           {
               Id = new Guid("a063fe8d-78e4-4fd5-86a2-57e9f8c5b44e"),
               Name = "Service B",
               BasePrice = 0.24m,
               IsWorkingDayService = true,
           },
            new Service
            {
                Id = new Guid("b597eaab-7ab2-4c67-9fd0-c44b9c8b79e0"),
                Name = "Service C",
                BasePrice = 0.4m,
                IsWorkingDayService = false,
            }
        );

        modelBuilder.Entity<CustomerService>().HasData(
            //Test case 1
            new CustomerService
            {
                Id = Guid.NewGuid(),
                CustomerId = new Guid("d7b2c1b1-84c3-4e51-ade6-d2ab5043ed15"),
                ServiceId = new Guid("5e162f58-1f6d-4db0-b59f-c82e50aa7b4b"),
                ServiceStartDate = new DateTime(2019, 09, 20)
            },
            new CustomerService
            {
                Id = Guid.NewGuid(),
                CustomerId = new Guid("d7b2c1b1-84c3-4e51-ade6-d2ab5043ed15"),
                ServiceId = new Guid("b597eaab-7ab2-4c67-9fd0-c44b9c8b79e0"),
                Discount = 0.20m,
                DiscountStart = new DateTime(2019, 09, 22),
                DiscountEnd = new DateTime(2019, 09, 24),
                ServiceStartDate = new DateTime(2019, 09, 20)
            },


            //Test case 2
            new CustomerService
            {
                Id = Guid.NewGuid(),
                CustomerId = new Guid("3aeb3a2f-0e8d-4b88-b33c-5bc15b68b98b"),
                ServiceId = new Guid("a063fe8d-78e4-4fd5-86a2-57e9f8c5b44e"),
                Discount = 0.30m,
                DiscountStart = new DateTime(2018, 07, 20),
                DiscountEnd = new DateTime(2019, 10, 01),
                ServiceStartDate = new DateTime(2018, 01, 01)
            },
            new CustomerService
            {
                Id = Guid.NewGuid(),
                CustomerId = new Guid("3aeb3a2f-0e8d-4b88-b33c-5bc15b68b98b"),
                ServiceId = new Guid("b597eaab-7ab2-4c67-9fd0-c44b9c8b79e0"),
                Discount = 0.30m,
                DiscountStart = new DateTime(2018, 07, 20),
                DiscountEnd = new DateTime(2019, 10, 01),
                ServiceStartDate = new DateTime(2018, 01, 01)
            }
        );
    }
}
