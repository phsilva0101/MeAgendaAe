using AutoMapper;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.ViewModel.Empresas.Saida;
using MeAgendaAe.CamadaDados.Base;
using MeAgendaAe.Dominio.ViewModel.Empresas.Entrada;
using System.Threading;

namespace MeAgendaAe.CamadaDadosAcesso.Repositorio
{
    public class EmpresaRepositorio : BaseRepositorio<MeAgendaAeContext, TbEmpresas>, IEmpresasRepositorio
    {

        public EmpresaRepositorio(MeAgendaAeContext context) : base(context)
        {

        }

        public async Task<(long count, IEnumerable<TbEmpresas>)> ObterTodasEmpresasPaginados(EmpresaRequestQueryViewModel request, CancellationToken cancellationToken)
        {

            var query = _context.TbEmpresas.Where(x => x.DataDesativacao == null).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.TermoBusca))
                query = query.Where(x => x.NomeEmpresa == request.TermoBusca);

            query = query.OrderBy(x => x.NomeEmpresa);

            long count = await query.LongCountAsync(cancellationToken);

            var entidade = await query.Skip((request.NumeroPagina - 1) * request.TamanhoPagina).Take(request.TamanhoPagina).ToListAsync(cancellationToken);

            return (count, entidade);

        }

        public async Task<TbEmpresas> ObterEmpresasPorId(Guid idEmpresa, CancellationToken cancellationToken)
        {
            return await _context.TbEmpresas.Where(x => x.Id == idEmpresa && x.DataDesativacao == null).FirstOrDefaultAsync();
        }
    }
}
