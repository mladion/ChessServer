using Domain;
using Domain.IRepository;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Shared.Models;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        services.AddDbContext<ChessDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        // Register repositories
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IRepository<ApplicationUser>, ApplicationUserRepository>();

        return services;
    }
}
