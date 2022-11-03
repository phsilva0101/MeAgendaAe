using MeAgendaAe.Dominio.Repositorio;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.CamadaDadosAcesso.Repositorio;
using MeAgendaAe.CrossCutting.Settings;
using MeAgendaAe.Dominio.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeAgendaAe.IoC;
using MeAgendaAe.Filtros;
using System.Text.Json.Serialization;

namespace MeAgendaAe
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

            var appConfig = Configuration.Get<ConfiguracoesDoApp>();

            services.AdicionarBancoDeDados(appConfig);
            services.AdicionarServicos(appConfig);
            services.ConfigurarAutoMapper();

            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(HttpGlobalExceptionFiltro));
                config.Filters.Add(new ValidarModelStateFiltro());
                config.Filters.Add<DominioValidacaoFiltro>();
            })
                .AddNewtonsoftJson()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MeAgendaAe",
                    Version = "v1",
                    Description = "Documentação - API Me Agenda Ae"
                });
            });

            services.AddCors(o => o.AddPolicy("AnyOriginPolicy", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeAgendaAe v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("AnyOriginPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
