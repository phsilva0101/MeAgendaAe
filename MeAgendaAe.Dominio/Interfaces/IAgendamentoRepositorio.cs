using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.Model;
using MeAgendaAe.Dominio.ViewModel.Agendamentos.Entrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.Dominio.Interfaces
{
    public interface IAgendamentoRepositorio : IBaseRepositorio<TbAgendamentos>
    {
        Task<(long count, IEnumerable<TbAgendamentos>)> ObterTodosAgendamentosPaginados(AgendamentsRequestQueryModel request, CancellationToken cancellationToken);
        Task<TbAgendamentos> ObterAgendamentoPorId(Guid id, CancellationToken cancellationToken);
        Task<string> ExisteAgendamentoCadastrado(int mesDataNovo, Guid idCliente, CancellationToken cancellationToken);

    }
}
