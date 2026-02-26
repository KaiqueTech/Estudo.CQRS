using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnackGestor.Application.Abstractions.Data;
using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Application.Commands.Produtos;
using SnackGestor.Domain.Abstractions;
using SnackGestor.Infra.Abstractions;
using SnackGestor.Infra.Persistense.Data;
using SnackGestor.Infra.Persistense.Repositories;

namespace SnackGestor.Infra.DependicyInjection
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            services.Scan(scan => scan
            .FromAssemblies(typeof(CommandDispatcher).Assembly)
            .FromApplicationDependencies()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.Scan(scan => scan
            .FromAssemblies(typeof(QueryDispatcher).Assembly)
            .AddClasses(classes =>
                classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
