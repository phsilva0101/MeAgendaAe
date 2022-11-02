using AutoMapper;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeAgendaAe.Dominio.Interfaces;
using MeAgendaAe.CamadaDados.Base;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.Enums;
using MeAgendaAe.Dominio.ViewModel.Agendamentos.Entrada;
using System.Threading;

namespace MeAgendaAe.Dominio.Repositorio
{
    public class AgendamentoRepositorio : BaseRepositorio<MeAgendaAeContext, TbAgendamentos>, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(MeAgendaAeContext context) : base(context)
        {

        }


        public async Task<string> ExisteAgendamentoCadastrado(int mesDataNovo, Guid idCliente, CancellationToken cancellationToken)
        {
            return await _context.TbAgendamentos.Where(x => x.DataAgendamento.Month == mesDataNovo && x.IdCliente == idCliente && x.IdStatusAgendamento == (long)EnumStatusAgendamento.Agendado).Select(x => x.NumeroAgendamento).FirstOrDefaultAsync();
        }

        public Task<bool> FinalizarAgendamento(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<TbAgendamentos> ObterAgendamentoPorId(Guid id, CancellationToken cancellationToken)
        {
            return await _context.TbAgendamentos.Include(x => x.TbCliente).Where(x => x.Id == id && x.DataDesativacao == null).FirstOrDefaultAsync();
        }

        public async Task<(long count, IEnumerable<TbAgendamentos>)> ObterTodosAgendamentosPaginados(AgendamentsRequestQueryModel request, CancellationToken cancellationToken)
        {

            var query = _context.TbAgendamentos.Where(x => x.DataDesativacao == null).AsQueryable();

            if (request.DataAgendamento != null)
                query = query.Where(x => x.DataAgendamento == request.DataAgendamento);

            query = query.OrderByDescending(x => x.DataRegistro);
            long count = await query.LongCountAsync(cancellationToken);

            var agendamento = await query.Skip((request.NumeroPagina - 1) * request.TamanhoPagina).Take(request.TamanhoPagina).ToListAsync(cancellationToken);

            return (count, agendamento);
        }

    }
}
