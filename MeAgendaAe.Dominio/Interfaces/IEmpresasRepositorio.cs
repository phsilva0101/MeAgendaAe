using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.ViewModel.Empresas.Entrada;
using MeAgendaAe.Dominio.ViewModel.Empresas.Saida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Interfaces
{
    public interface IEmpresasRepositorio : IBaseRepositorio<TbEmpresas>
    {
        Task<(long count, IEnumerable<TbEmpresas>)> ObterTodasEmpresasPaginados(EmpresaRequestQueryViewModel request, CancellationToken cancellationToken);
        Task<TbEmpresas> ObterEmpresasPorId(Guid idEmpresa, CancellationToken cancellationToken);
        
    }
}
