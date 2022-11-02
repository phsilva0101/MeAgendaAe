using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.ViewModel.Clientes.Entrada;
using MeAgendaAe.Dominio.ViewModel.Clientes.Saida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Interfaces
{
    public interface IClienteRepositorio : IBaseRepositorio<TbCliente>
    {
        Task<(long count, IEnumerable<TbCliente>)> ObterTodosClientes(ClientesRequestQueryViewModel request, CancellationToken cancellationToken);
        Task<TbCliente> ObterClientesPorId(Guid idCliente, CancellationToken cancellationToken);
    

    }
}
