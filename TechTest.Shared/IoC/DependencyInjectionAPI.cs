using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechTest.Application.Mappings;
using TechTest.Domain.Interfaces;
using TechTest.Infrastructure.Context;
using TechTest.Infrastructure.Repositories;

namespace TechTest.Shared.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
           options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                 new MySqlServerVersion(new Version(8, 0, 11))));

        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        services.AddScoped<MongoRepository>();

        return services;
    }
}
