using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Base
{
    public interface IUnidadeDeTrabalhoRepositorio<TContext> where TContext : class
    {
        Task CommitarTransacao(CancellationToken cancellationToken = default);
    }
}
