using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Soccer.Infrastructure.EF;

namespace Soccer.Infrastructure.Extensions;

public static class SoccerContextExtensions
{
    public static void AddSoccerContext(this IServiceCollection services, string connection) =>
        services.AddDbContext<SoccerContext>(options => options.UseSqlServer(connection));
}