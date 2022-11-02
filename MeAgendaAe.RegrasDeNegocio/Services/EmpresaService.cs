using AutoMapper;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.CamadaDadosAcesso.Repositorio;
using MeAgendaAe.Dominio.Base;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.ViewModel;
using MeAgendaAe.Dominio.ViewModel.Clientes.Saida;
using MeAgendaAe.Dominio.ViewModel.Empresas.Entrada;
using MeAgendaAe.Dominio.ViewModel.Empresas.Saida;
using MeAgendaAe.RegrasDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.RegrasDeNegocio.Services
{
    public class EmpresaService : IEmpresaServices
    {
        private readonly IEmpresasRepositorio _empresaRepo;
        private readonly IUnidadeDeTrabalhoRepositorio<MeAgendaAeContext> _unidadeDeTrabalhoRepositorio;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresasRepositorio empresaRepo, IMapper mapper, IUnidadeDeTrabalhoRepositorio<MeAgendaAeContext> unidadeDeTrabalhoRepositorio)
        {
            _empresaRepo = empresaRepo;
            _mapper = mapper;
            _unidadeDeTrabalhoRepositorio = unidadeDeTrabalhoRepositorio;
        }
        public async Task<EmpresasModel> ObterEmpresasPeloId(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _empresaRepo.ObterEmpresasPorId(id, cancellationToken);
            return _mapper.Map<EmpresasModel>(entidade);
        }

        public async Task<ItensPaginadosVW<EmpresasModel>> ObterTodasEmpresas(EmpresaRequestQueryViewModel request, CancellationToken cancellationToken)
        {
            (long count, IEnumerable<TbEmpresas> entities) = await _empresaRepo.ObterTodasEmpresasPaginados(request, cancellationToken);
            var models = _mapper.Map<IEnumerable<EmpresasModel>>(entities);
            return new ItensPaginadosVW<EmpresasModel>(request.TamanhoPagina, request.NumeroPagina, count, models);
        }
    }
}
