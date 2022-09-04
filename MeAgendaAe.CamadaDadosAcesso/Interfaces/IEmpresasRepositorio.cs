using MeAgendaAe.CamadaDados.Tabelas;
using MeAgendaAe.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Interfaces
{
    public interface IEmpresasRepositorio
    {
        Task<Empresas> ObterEmpresas();
        Task<Empresas> ObterEmpresasPorId(long idEmpresa);
        Task<Empresas> AdicionarEmpresa(TbEmpresas tbEmpresas);
        Task<Empresas> AtualizarEmpresa(TbEmpresas tbEmpresas);
        Task<bool> ExcluirEmpresa(long idEmpresa);
        Task<bool> InativarEmpresa(long idEmpresa);
    }
}
