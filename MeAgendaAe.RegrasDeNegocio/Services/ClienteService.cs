using AutoMapper;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.ViewModel;
using MeAgendaAe.Dominio.ViewModel.Clientes.Entrada;
using MeAgendaAe.Dominio.ViewModel.Clientes.Saida;
using MeAgendaAe.RegrasDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.RegrasDeNegocio.Services
{
    public class ClienteService : IClientesService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IUnidadeDeTrabalhoRepositorio<MeAgendaAeContext> _unidadeDeTrabalhoRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepositorio clienteRepositorio, IMapper mapper, IUnidadeDeTrabalhoRepositorio<MeAgendaAeContext> unidadeDeTrabalhoRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
            _unidadeDeTrabalhoRepositorio = unidadeDeTrabalhoRepositorio;
        }

        public async Task<ClientesModel> AtualizarCliente(TbCliente cliente, CancellationToken cancellationToken)
        {
            var entidade = await _clienteRepositorio.ObterClientesPorId(cliente.Id, cancellationToken);

            entidade.Idade = cliente.Idade;
            entidade.IdCidade = cliente.IdCidade;
            entidade.IdEstado = cliente.IdEstado;
            entidade.CPF = cliente.CPF;
            entidade.DataNascimento = cliente.DataNascimento;
            entidade.Email = cliente.Email;
            entidade.Nome = cliente.Nome;
            entidade.Telefone = cliente.Telefone;

            await _unidadeDeTrabalhoRepositorio.CommitarTransacao(cancellationToken);

            return _mapper.Map<ClientesModel>(entidade);

        }

        public async Task<ClientesModel> InserirCliente(TbCliente cliente, CancellationToken cancellationToken)
        {
            await _clienteRepositorio.CriarAsync(cliente);
            await _unidadeDeTrabalhoRepositorio.CommitarTransacao();

            return _mapper.Map<ClientesModel>(cliente);
        }

        public async Task<ClientesModel> ObterClientePeloId(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _clienteRepositorio.ObterClientesPorId(id, cancellationToken);
            return _mapper.Map<ClientesModel>(entidade);
        }

        public async Task<ItensPaginadosVW<ClientesModel>> ObterTodosClientes(ClientesRequestQueryViewModel request, CancellationToken cancellationToken)
        {
            (long count, IEnumerable<TbCliente> entities) = await _clienteRepositorio.ObterTodosClientes(request, cancellationToken);
            var models = _mapper.Map<IEnumerable<ClientesModel>>(entities);
            return new ItensPaginadosVW<ClientesModel>(request.TamanhoPagina, request.NumeroPagina, count, models);

        }
    }
}
