using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.ViewModel;
using MeAgendaAe.Dominio.ViewModel.Clientes.Entrada;
using MeAgendaAe.Dominio.ViewModel.Clientes.Saida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.RegrasDeNegocio.Interfaces
{
    public interface IClientesService
    {
        public Task<ItensPaginadosVW<ClientesModel>> ObterTodosClientes(ClientesRequestQueryViewModel request, CancellationToken cancellationToken);
        public Task<ClientesModel> ObterClientePeloId(Guid id, CancellationToken cancellationToken);
        public Task<ClientesModel> InserirCliente(TbCliente cliente, CancellationToken cancellationToken);
        public Task<ClientesModel> AtualizarCliente(TbCliente cliente, CancellationToken cancellationToken);
    }
}
