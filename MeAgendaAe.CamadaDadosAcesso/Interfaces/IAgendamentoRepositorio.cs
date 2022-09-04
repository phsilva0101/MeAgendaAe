using MeAgendaAe.CamadaDados.Tabelas;
using MeAgendaAe.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Interfaces
{
    public interface IAgendamentoRepositorio
    {
        Task<List<Agendamentos>> ObterTodosAgendamentos();
        Task<Agendamentos> ObterAgendamentoPorId(long id);
        Task<bool> FinalizarAgendamento(long id);
        Task<Agendamentos> CriarAgendamento(TbAgendamentos tbAgendamentos);
        Task<Agendamentos> AtualizarAgendamentos(TbAgendamentos tbAgendamentos);
        Task<bool> ExcluirAgendamento(long id);

    }
}
