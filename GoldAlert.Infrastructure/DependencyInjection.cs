using GoldAlert.Infrastructure.Persistence;
using GoldAlert.Infrastructure.Persistence.Repositories;
using GoldPing.Application.Contracts.Persistence;
using GoldPing.Infrastructure.Persistence;
using GoldPing.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<GoldPingDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPriceAlertRepository, PriceAlertRepository>();

        return services;
    }
}