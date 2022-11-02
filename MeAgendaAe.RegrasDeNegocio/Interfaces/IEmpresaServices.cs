using MeAgendaAe.Dominio.ViewModel.Clientes.Entrada;
using MeAgendaAe.Dominio.ViewModel.Clientes.Saida;
using MeAgendaAe.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MeAgendaAe.Dominio.ViewModel.Empresas.Saida;
using MeAgendaAe.Dominio.ViewModel.Empresas.Entrada;

namespace MeAgendaAe.RegrasDeNegocio.Interfaces
{
    public interface IEmpresaServices
    {
        public Task<ItensPaginadosVW<EmpresasModel>> ObterTodasEmpresas(EmpresaRequestQueryViewModel request, CancellationToken cancellationToken);
        public Task<EmpresasModel> ObterEmpresasPeloId(Guid id, CancellationToken cancellationToken);
    }
}
