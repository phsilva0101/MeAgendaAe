using MeAgendaAe.CamadaDados.Tabelas;
using MeAgendaAe.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<Clientes>> ObterTodosClientes();
        Task<Clientes> ObterClientesPorId(long idCliente);
        Task<Clientes> AdicionarCliente(TbCliente tbCliente);
        Task<Clientes> AtualizarCliente(TbCliente tbCliente);
        Task<bool> ExcluirCliente(long idCliente);

    }
}
