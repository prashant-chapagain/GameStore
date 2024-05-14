using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await DbContext.Database.MigrateAsync();
    }
    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var ConString = configuration.GetConnectionString("GameStoreContext");
#pragma warning disable CS8604 // Possible null reference argument.
        services.AddDbContext<GameStoreContext>(options =>
        options.UseMySQL(ConString))
#pragma warning restore CS8604 // Possible null reference argument.
                .AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();
        return services;
    }
}