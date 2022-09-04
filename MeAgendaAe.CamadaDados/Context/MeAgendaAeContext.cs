using MeAgendaAe.CamadaDados.Tabelas;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace MeAgendaAe.CamadaDados.Context
{
    public class MeAgendaAeContext : DbContext
    {
        public MeAgendaAeContext(DbContextOptions<MeAgendaAeContext> options) : base(options)
        {

        }

        public DbSet<TbAgendamentos> TbAgendamentos { get; set; }
        public DbSet<TbCidades> TbCidades { get; set; }
        public DbSet<TbCliente> TbCliente { get; set; }
        public DbSet<TbConfiguracoes> TbConfiguracoes { get; set; }
        public DbSet<TbEmpresas> TbEmpresas { get; set; }
        public DbSet<TbEstados> TbEstados { get; set; }
        public DbSet<TbFormasPagamentos> TbFormasPagamentos { get; set; }
        public DbSet<TbPaises> TbPaises { get; set; }
        public DbSet<TbPagamentos> TbPagamentos { get; set; }
        public DbSet<TbStatusAgendamentos> TbStatusAgendamentos { get; set; }
        public DbSet<TbUsuarios> TbUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global turn off delete behaviour on foreign keys
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
