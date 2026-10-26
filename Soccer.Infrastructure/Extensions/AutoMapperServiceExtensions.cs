using Microsoft.Extensions.DependencyInjection;
using Soccer.Application.Profiles;

namespace Soccer.Infrastructure.Extensions;

public static class AutoMapperServiceExtensions
{
    public static void AddSoccerAutoMapper(this IServiceCollection services)
    {
        // Передаємо очікуваний Action<IMapperConfigurationExpression> 
        // і реєструємо профіль через метод AddProfile
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<SoccerProfile>();
        });
    }
}