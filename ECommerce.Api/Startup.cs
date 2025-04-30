using ECommerce.Application.Features.Clientes.Commands.Handlers;
using ECommerce.Application.Features.Clientes.Commands.Requests;
using ECommerce.Application.Features.Clientes.Queries.Handlers;
using ECommerce.Application.Features.Clientes.Queries.Requests;
using ECommerce.Application.Features.Clientes.Queries.Responses;
using ECommerce.Application.Features.Pedidos.Commands.Handlers;
using ECommerce.Application.Features.Pedidos.Commands.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Handlers;
using ECommerce.Application.Features.Pedidos.Queries.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Responses;
using ECommerce.Application.Features.Produtos.Commands.Handlers;
using ECommerce.Application.Features.Produtos.Commands.Requests;
using ECommerce.Application.Features.Produtos.Queries.Handlers;
using ECommerce.Application.Features.Produtos.Queries.Requests;
using ECommerce.Application.Features.Produtos.Queries.Responses;
using ECommerce.Application.Services;
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

                options.UseAllOfToExtendReferenceSchemas();
            });

            services.AddInfrastructureServices(Configuration);

            // Cliente
            services.AddScoped<IRequestHandler<CreateClienteCommandRequest, bool>, CreateClienteCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteClienteCommandRequest, bool>, DeleteClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommandRequest, bool>, UpdateClienteCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllClientesQueryRequest, IEnumerable<GetAllClientesQueryResponse>>, GetAllClientesQueryHandler>();
            services.AddScoped<IRequestHandler<GetClienteByIdQueryRequest, GetClienteByIdQueryResponse?>, GetClienteByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetClienteByNomeQueryRequest, IEnumerable<GetClienteByNomeQueryResponse>>, GetClienteByNomeQueryHandler>();

            // Produto
            services.AddScoped<IRequestHandler<CreateProdutoCommandRequest, bool>, CreateProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProdutoCommandRequest, bool>, DeleteProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProdutoCommandRequest, bool>, UpdateProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllProdutosQueryRequest, IEnumerable<GetAllProdutosQueryResponse>>, GetAllProdutosQueryHandler>();
            services.AddScoped<IRequestHandler<GetProdutoByIdQueryRequest, GetProdutoByIdQueryResponse?>, GetProdutoByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetProdutoByNomeQueryRequest, IEnumerable<GetProdutoByNomeQueryResponse>>, GetProdutoByNomeQueryHandler>();

            // Pedido
            services.AddScoped<IRequestHandler<CreatePedidoCommandRequest, bool>, CreatePedidoCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePedidoCommandRequest, bool>, DeletePedidoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePedidoCommandRequest, bool>, UpdatePedidoCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllPedidosQueryRequest, IEnumerable<GetAllPedidosQueryResponse>>, GetAllPedidosQueryHandler>();
            services.AddScoped<IRequestHandler<GetPedidoByIdQueryRequest, GetPedidoByIdQueryResponse?>, GetPedidoByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetPedidosByClienteNomeQueryRequest, IEnumerable<GetPedidosByClienteNomeQueryResponse>>, GetPedidoByNomeQueryHandler>();
            services.AddScoped<IRequestHandler<GetPedidosByStatusQueryRequest, IEnumerable<GetPedidosByStatusQueryResponse>>, GetPedidosByStatusQueryHandler>();

            // Repositórios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            // Serviços
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoService, PedidoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Desafio Final V1");
                    options.RoutePrefix = string.Empty;
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
