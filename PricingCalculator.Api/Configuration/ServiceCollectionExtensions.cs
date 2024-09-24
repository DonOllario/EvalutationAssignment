using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using PricingCalculator.Domain.Interfaces;
using PricingCalculator.DataAccess;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.DataAccess.Repositories;
using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Logic.Commands;

namespace PricingCalculator.Api.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppConfig>(configuration.GetSection(nameof(AppConfig)));
        services.AddSingleton<IAppConfig>(s => s.GetRequiredService<IOptions<AppConfig>>().Value);
        services.AddTransient<ICustomerCommands, CustomerCommands>();

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
    }
}
