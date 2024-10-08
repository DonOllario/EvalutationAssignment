﻿using Microsoft.EntityFrameworkCore;
using PricingCalculator.DataAccess;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.DataAccess.Repositories;
using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Logic.Commands;
using PricingCalculator.Domain.Interfaces.Queries;
using PricingCalculator.Logic.Queries;

namespace PricingCalculator.Api.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICustomerCommands, CustomerCommands>();
        services.AddTransient<IServiceCommands, ServiceCommands>();
        services.AddTransient<ICustomerServiceCommands, CustomerServiceCommands>();
        services.AddTransient<ICustomerServiceQueries, CustomerServiceQueries>();

        services.AddEntityFramework(configuration);

        services.AddDataAccessServices();
    }

    public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void AddDataAccessServices(this IServiceCollection services)
    {
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<ICustomerServiceRepository, CustomerServiceRepository>();
    }
}
