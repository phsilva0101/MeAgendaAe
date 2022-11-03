using AutoMapper;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.Enums;
using MeAgendaAe.Dominio.Interfaces;
using MeAgendaAe.Dominio.Model;
using MeAgendaAe.Dominio.ViewModel;
using MeAgendaAe.Dominio.ViewModel.Agendamentos.Entrada;
using MeAgendaAe.RegrasDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.RegrasDeNegocio.Services
{
    public class AgendamentosServices : IAgendamentosServices
    {
        private readonly IAgendamentoRepositorio _agendamentoRepo;
        private readonly IClienteRepositorio _clienteRepo;
        private readonly IUnidadeDeTrabalhoRepositorio<MeAgendaAeContext> _unidTrabRepo;
        private readonly IMapper _mapper;

        public AgendamentosServices(IAgendamentoRepositorio agendamentoRepo, 
            IMapper mapper, 
            IUnidadeDeTrabalhoRepositorio<MeAgendaAeContext> unidadeDeTrabalhoRepositorio,
            IClienteRepositorio clienteRepositorio)
        {
            _agendamentoRepo = agendamentoRepo;
            _mapper = mapper;
            _unidTrabRepo = unidadeDeTrabalhoRepositorio;
            _clienteRepo = clienteRepositorio;
        }

        public async Task<Agendamentos> CancelarAgendamento(CancelarAgendamentoRequestViewModel requestViewModel, CancellationToken cancellationToken)
        {
            var entidade = await _agendamentoRepo.ObterAgendamentoPorId(requestViewModel.IdAgendamento, cancellationToken);

            entidade.IdStatusAgendamento = (long)EnumStatusAgendamento.Cancelado;
            entidade.DataDesativacao = DateTime.Now;
            entidade.MotivoCancelamento = requestViewModel.MotivoCancelamento;

            await _unidTrabRepo.CommitarTransacao(cancellationToken);

            return _mapper.Map<Agendamentos>(entidade);
        }

        public async Task<Agendamentos> FinalizarAgendamento(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _agendamentoRepo.ObterAgendamentoPorId(id, cancellationToken);

            entidade.IdStatusAgendamento = (long)EnumStatusAgendamento.Finalizado;

            var cliente = await _clienteRepo.ObterClientesPorId(entidade.IdCliente, cancellationToken);

            cliente.QtdVisitas += 1;

            await _unidTrabRepo.CommitarTransacao(cancellationToken);

            return _mapper.Map<Agendamentos>(entidade);
        }

        public async Task<Agendamentos> NovoAgendamento(TbAgendamentos entidade, CancellationToken cancellationToken)
        {
            int mesDataAtual = DateTime.Now.Month;
            int mesDataAgendamento = entidade.DataAgendamento.Month;

            string numeroAgendamento = await _agendamentoRepo.ExisteAgendamentoCadastrado(mesDataAgendamento, entidade.IdCliente, cancellationToken);

            if (!string.IsNullOrWhiteSpace(numeroAgendamento))
                return null;

            await _agendamentoRepo.CriarAsync(entidade);
            await _unidTrabRepo.CommitarTransacao(cancellationToken);

            return _mapper.Map<Agendamentos>(entidade);

        }

        public async Task<Agendamentos> ObterAgendamentoPeloId(Guid id, CancellationToken cancellationToken)
        {
            TbAgendamentos entidade = await _agendamentoRepo.ObterAgendamentoPorId(id, cancellationToken);
            Agendamentos agendamento = _mapper.Map<Agendamentos>(entidade);
            return agendamento;
        }

        public async Task<ItensPaginadosVW<Agendamentos>> ObterTodos(AgendamentsRequestQueryModel request, CancellationToken cancellationToken)
        {
            (long count, IEnumerable<TbAgendamentos> entities) = await _agendamentoRepo.ObterTodosAgendamentosPaginados(request, cancellationToken);
            List<Agendamentos> agendamentos = _mapper.Map<List<Agendamentos>>(entities);
            return new ItensPaginadosVW<Agendamentos>(request.NumeroPagina, request.TamanhoPagina, count, agendamentos);
        }
    }
}
