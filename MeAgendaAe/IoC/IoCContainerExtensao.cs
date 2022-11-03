using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.CamadaDadosAcesso.Repositorio;
using MeAgendaAe.Config;
using MeAgendaAe.CrossCutting.Settings;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.Dominio.Interfaces;
using MeAgendaAe.Dominio.Repositorio;
using MeAgendaAe.Dominio.Validacao;
using MeAgendaAe.RegrasDeNegocio.Interfaces;
using MeAgendaAe.RegrasDeNegocio.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MeAgendaAe.IoC
{
    public static class IoCContainerExtensao
    {
        public static IServiceCollection AdicionarBancoDeDados(this IServiceCollection services, ConfiguracoesDoApp config)
        {
            if (config.IsSQLServer)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseSqlServer(config.ConnectionStrings.SQLSERVER));
            else if (config.IsPostgre)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseNpgsql(config.ConnectionStrings.POSTGRE));
            else if (config.IsOracle)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseOracle(config.ConnectionStrings.ORACLE));
            else if (config.IsMySQL)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseMySql(config.ConnectionStrings.MYSQL, new MySqlServerVersion(new Version(8, 0, 30))));

            return services;

        }

        public static void AdicionarServicos(this IServiceCollection services, ConfiguracoesDoApp configuracoes)
        {
            services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IEmpresasRepositorio, EmpresaRepositorio>();
            services.AddSingleton<IAgendamentosServices, AgendamentosServices>();
            services.AddSingleton<IClientesService, ClienteService>();
            services.AddSingleton<IEmpresaServices, EmpresaService>();

            services.AddScoped<IDominioValidacaoService, DominioValidacaoService>();
        }

        public static void ConfigurarAutoMapper(this IServiceCollection services)
        {
            var mapper = MapperConfig.RegistrarMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
