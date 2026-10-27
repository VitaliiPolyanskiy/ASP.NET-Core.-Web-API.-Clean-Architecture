using Microsoft.Extensions.DependencyInjection;
using Soccer.Infrastructure.Services;
using Soccer.Application.Interfaces;

namespace Soccer.Infrastructure.Extensions;

public static class TeamServiceExtensions
{
    public static void AddTeamService(this IServiceCollection services) =>
        services.AddScoped<ITeamService, TeamService>();
}