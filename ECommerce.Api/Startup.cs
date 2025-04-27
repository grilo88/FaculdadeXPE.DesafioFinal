using ECommerce.Application.Features.Clientes.Commands.Handlers;
using ECommerce.Application.Features.Clientes.Commands.Requests;
using ECommerce.Application.Features.Clientes.Queries.Handlers;
using ECommerce.Application.Features.Clientes.Queries.Requests;
using ECommerce.Application.Features.Clientes.Queries.Responses;
using ECommerce.Application.Features.Clientes.Services;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Infrastructure.IoC;
using ECommerce.Infrastructure.Repositories;
using MediatR;

namespace ECommerce.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddOpenApi();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Ecommerce",
                    Version = "v1",
                    Description = "Desafio Final - Arquiteto de Software - Faculdade XPE"
                });

                // Se você quiser incluir um arquivo XML de comentários para mais detalhes
                // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "MinhaApi.xml"));
            });

            services.AddInfrastructureServices(Configuration);

            services.AddScoped<IRequestHandler<CreateClienteCommandRequest, bool>, CreateClienteCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteClienteCommandRequest, bool>, DeleteClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommandRequest, bool>, UpdateClienteCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllClientesQueryRequest, IEnumerable<GetAllClientesQueryResponse>>, GetAllClientesQueryHandler>();
            services.AddScoped<IRequestHandler<GetClienteByIdQueryRequest, GetClienteByIdQueryResponse?>, GetClienteByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetClienteByNomeQueryRequest, IEnumerable<GetClienteByNomeQueryResponse>>, GetClienteByNomeQueryHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); // <- Gera o swagger.json
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Desafio Final V1");
                    options.RoutePrefix = string.Empty; // Deixa o Swagger disponível na raiz da aplicação
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}