using Microsoft.Extensions.DependencyInjection;
using Soccer.Application.Interfaces;
using Soccer.Infrastructure.Repositories;

namespace Soccer.Infrastructure.Extensions;

public static class UnitOfWorkServiceExtensions
{
    public static void AddUnitOfWorkService(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, EFUnitOfWork>();
}