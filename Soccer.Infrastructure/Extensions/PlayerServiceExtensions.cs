using Microsoft.Extensions.DependencyInjection;
using Soccer.Infrastructure.Services;
using Soccer.Application.Interfaces;

namespace Soccer.Infrastructure.Extensions;

public static class PlayerServiceExtensions
{
    public static void AddPlayerService(this IServiceCollection services) =>
        services.AddScoped<IPlayerService, PlayerService>();
}