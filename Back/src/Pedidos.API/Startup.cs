using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pedidos.Application;
using Pedidos.Application.Contratos;
using Pedidos.Domain;
using Pedidos.Domain.Commands.Handlers;
using Pedidos.Domain.Commands.Handlers.Contratos;
using Pedidos.Persistence;
using Pedidos.Persistence.Contextos;
using Pedidos.Persistence.Contratos;

namespace Pedidos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PedidoContext>(opt => opt.UseInMemoryDatabase("PrdidosDb"));

             services.AddControllers()
                    .AddNewtonsoftJson(
                        x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddScoped<ISolicitacaoService, SolicitacaoService>();
            services.AddScoped<IGeralPersistence, GeralPersistence>();
            services.AddScoped<ISolicitacaoPersistence, SolicitacaoPersistence>();
            services.AddScoped<ICreateStatusHandler, CreateStatusHandler>();

            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pedidos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedidos.API v1"));
               
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors => cors.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin());

            // var context = app.ApplicationServices.GetService<PedidoContext>();
            // AdicionarDadosTeste(context);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AdicionarDadosTeste(PedidoContext context)
        {
            var itemA = new Itens(){Descricao ="Item A",PrecoUnitario = 10, qtd = 1};
            var itemB = new Itens(){Descricao ="Item B",PrecoUnitario = 5, qtd = 2};

            var listaItens = new List<Itens>();
            listaItens.Add(itemA);
            listaItens.Add(itemB);

            var pedido = new Solicitacao()
            {
                Itens = listaItens
            };

            context.AddAsync(pedido);
            context.SaveChangesAsync();
        }
    }
}
