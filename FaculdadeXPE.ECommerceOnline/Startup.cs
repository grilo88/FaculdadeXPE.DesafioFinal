using FaculdadeXPE.ECommerceOnline.Application.Features.Clientes.Commands.Handlers;
using FaculdadeXPE.ECommerceOnline.Application.Features.Clientes.Commands.Requests;
using FaculdadeXPE.ECommerceOnline.Infrastructure.IoC;
using MediatR;

namespace FaculdadeXPE.ECommerceOnline.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Adicionar serviços (injeção de dependência, etc.)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configurar o OpenAPI
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
        }

        // Configurar o pipeline HTTP
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

                //app.MapOpenApi();
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