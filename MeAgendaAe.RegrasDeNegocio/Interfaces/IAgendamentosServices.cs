using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.Model;
using MeAgendaAe.Dominio.ViewModel;
using MeAgendaAe.Dominio.ViewModel.Agendamentos.Entrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.RegrasDeNegocio.Interfaces
{
    public interface IAgendamentosServices
    {
        public Task<ItensPaginadosVW<Agendamentos>> ObterTodos(AgendamentsRequestQueryModel model, CancellationToken cancellationToken);
        public Task<Agendamentos> ObterAgendamentoPeloId(Guid id, CancellationToken cancellationToken);
        public Task<Agendamentos> NovoAgendamento(TbAgendamentos entidade, CancellationToken cancellationToken);
        public Task<Agendamentos> CancelarAgendamento(CancelarAgendamentoRequestViewModel requestViewModel, CancellationToken cancellationToken);
        public Task<Agendamentos> FinalizarAgendamento(Guid id, CancellationToken cancellationToken);

    }
}
