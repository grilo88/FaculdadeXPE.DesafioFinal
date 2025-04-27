using FaculdadeXPE.ECommerceOnline.Domain.Contracts;
using FaculdadeXPE.ECommerceOnline.Domain.Repositories;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Data.Contexts;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Persistence;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FaculdadeXPE.ECommerceOnline.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=app.db").EnableSensitiveDataLogging());

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
