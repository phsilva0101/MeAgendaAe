using MeAgendaAe.CamadaDados.Context;
using MeAgendaAe.CrossCutting.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeAgendaAe.CrossCutting.MetodosExtensao
{
    public static class ExntensaoCollections
    {
        public static IServiceCollection AdicionarBancoDeDados(this IServiceCollection services, ConfiguracoesDoApp config)
        {
            if (config.IsSQLServer)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseSqlServer(config.ConnectionStrings.SQLSERVER));
            else if(config.IsPostgre)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseNpgsql(config.ConnectionStrings.POSTGRE));
            else if (config.IsOracle)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseOracle(config.ConnectionStrings.ORACLE));
            else if(config.IsMySQL)
                services.AddDbContext<MeAgendaAeContext>(options => options.UseMySql(config.ConnectionStrings.MYSQL, new MySqlServerVersion(new Version(8, 0, 30))));

            return services;

        }
    }
}
