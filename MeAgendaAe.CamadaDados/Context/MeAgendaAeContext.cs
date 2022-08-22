using MeAgendaAe.CamadaDados.Tabelas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Context
{
    public class MeAgendaAeContext : DbContext
    {
        public MeAgendaAeContext(DbContextOptions<MeAgendaAeContext> options) : base(options)
        {

        }

        public DbSet<TbAgendamentos> TbAgendamentos { get; set; }
        public DbSet<TbCidades> TbCidades { get; set; }
        public DbSet<TbConfiguracoes> TbConfiguracoes { get; set; }
        public DbSet<TbEmpresas> TbEmpresas { get; set; }
        public DbSet<TbEstados> TbEstados { get; set; }
        public DbSet<TbFormasPagamentos> TbFormasPagamentos { get; set; }
        public DbSet<TbPagamentos> TbPagamentos { get; set; }
        public DbSet<TbUsuarios> TbUsuarios { get; set; }
    }
}
