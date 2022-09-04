using MeAgendaAe.CamadaDados.Tabelas;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Repositorio
{
    public class EmpresaRepositorio : IEmpresasRepositorio
    {
        public Task<Empresas> AdicionarEmpresa(TbEmpresas tbEmpresas)
        {
            throw new NotImplementedException();
        }

        public Task<Empresas> AtualizarEmpresa(TbEmpresas tbEmpresas)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirEmpresa(long idEmpresa)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InativarEmpresa(long idEmpresa)
        {
            throw new NotImplementedException();
        }

        public Task<Empresas> ObterEmpresas()
        {
            throw new NotImplementedException();
        }

        public Task<Empresas> ObterEmpresasPorId(long idEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
