using AutoMapper;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.Dominio.Tabelas;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeAgendaAe.Dominio.Entidades;

namespace MeAgendaAe.CamadaDadosAcesso.Repositorio
{
    public class EmpresaRepositorio : IEmpresasRepositorio
    {
        private readonly MeAgendaAeContext _context;
        private IMapper _mapper;
        public EmpresaRepositorio(MeAgendaAeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Empresas> AdicionarEmpresa(TbEmpresas tbEmpresas)
        {
            try
            {
                TbEmpresas empresa = await _context.TbEmpresas.Where(x => x.NomeEmpresa == tbEmpresas.NomeEmpresa).FirstOrDefaultAsync();

                if (empresa != null)
                    return null;

                await _context.TbEmpresas.AddAsync(tbEmpresas);
                await _context.SaveChangesAsync();

                return _mapper.Map<Empresas>(tbEmpresas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Empresas> AtualizarEmpresa(TbEmpresas tbEmpresas)
        {
            try
            {
                TbEmpresas empresa = await _context.TbEmpresas.Where(x => x.IdEmpresa == tbEmpresas.IdEmpresa).FirstOrDefaultAsync();

                if (empresa == null)
                    return null;

                 _context.TbEmpresas.Update(tbEmpresas);
                await _context.SaveChangesAsync();

                return _mapper.Map<Empresas>(tbEmpresas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ExcluirEmpresa(long idEmpresa)
        {
            try
            {
                TbEmpresas empresa = await _context.TbEmpresas.Where(x => x.IdEmpresa == idEmpresa).FirstOrDefaultAsync();

                if (empresa == null)
                    return false;

                _context.TbEmpresas.Remove(empresa);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    

        public async Task<bool> InativarEmpresa(long idEmpresa, bool isAtivo)
        {
            try
            {
                TbEmpresas empresa = await _context.TbEmpresas.Where(x => x.IdEmpresa == idEmpresa).FirstOrDefaultAsync();

                if (empresa == null)
                    return false;

                empresa.Ativo = isAtivo;
                _context.TbEmpresas.Update(empresa);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Empresas> ObterEmpresas()
        {
            try
            {
                List<TbEmpresas> empresas = await _context.TbEmpresas.AsNoTracking().ToListAsync();

                if (empresas == null)
                    return null;

                return _mapper.Map<Empresas>(empresas);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Empresas> ObterEmpresasPorId(long idEmpresa)
        {
            try
            {
                TbEmpresas empresa = await _context.TbEmpresas.Where(x => x.IdEmpresa == idEmpresa).AsNoTracking().FirstOrDefaultAsync();

                if (empresa == null)
                    return null;

                return _mapper.Map<Empresas>(empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
