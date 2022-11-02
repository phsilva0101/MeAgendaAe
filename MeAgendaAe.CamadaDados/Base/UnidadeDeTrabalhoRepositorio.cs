using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDados.Base
{
    public class UnidadeDeTrabalhoRepositorio<TContext> : IUnidadeDeTrabalhoRepositorio<TContext> where TContext : MeAgendaAeContext
    {
        private readonly MeAgendaAeContext _context;
        public UnidadeDeTrabalhoRepositorio(TContext context)
        {
            _context = context;
        }
        public async Task CommitarTransacao(CancellationToken cancellationToken = default)
        {
            if (_context.ChangeTracker.HasChanges())
                await _context.SaveChangesAsync();
        }
    }

}
