using AutoMapper;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeAgendaAe.Dominio.ViewModel.Clientes.Saida;
using MeAgendaAe.CamadaDados.Base;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.ViewModel.Clientes.Entrada;
using System.Threading;

namespace MeAgendaAe.CamadaDadosAcesso.Repositorio
{
    public class ClienteRepositorio : BaseRepositorio<MeAgendaAeContext, TbCliente>, IClienteRepositorio
    {

        public ClienteRepositorio(MeAgendaAeContext context) : base(context)
        {
        }

        public async Task<TbCliente> ObterClientesPorId(Guid idCliente, CancellationToken cancellationToken)
        {
            return await _context.TbCliente.Where(x => x.Id == idCliente && x.DataDesativacao == null).FirstOrDefaultAsync();
        }

        public async Task<(long count, IEnumerable<TbCliente>)> ObterTodosClientes(ClientesRequestQueryViewModel request, CancellationToken cancellationToken)
        {
           
                var query = _context.TbCliente.Where(x => x.DataDesativacao == null).AsQueryable();

                if (!string.IsNullOrWhiteSpace(request.Nome))
                    query = query.Where(x => x.Nome == request.Nome);

                query = query.OrderBy(x => x.Nome);

                long count = await query.LongCountAsync(cancellationToken);

                var entidade = await query.Skip((request.NumeroPagina - 1) * request.TamanhoPagina).Take(request.TamanhoPagina).ToListAsync(cancellationToken);

                return (count, entidade);
            }
    }
}
