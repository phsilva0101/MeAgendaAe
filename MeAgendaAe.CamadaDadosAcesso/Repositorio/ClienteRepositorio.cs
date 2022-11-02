using AutoMapper;
using MeAgendaAe.Dominio.Context;
using MeAgendaAe.Dominio.Tabelas;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly MeAgendaAeContext _context;
        private IMapper _mapper;

        public ClienteRepositorio(MeAgendaAeContext context, IMapper mapper)
        {
            _context = context;
            _mapper =  mapper;
        }
        public async Task<Clientes> AdicionarCliente(TbCliente tbCliente)
        {
            try
            {
                TbCliente entidade = await _context.TbCliente.Where(x => x.IdCliente == tbCliente.IdCliente).AsNoTracking().FirstOrDefaultAsync();

                if (entidade != null)
                    return null;

                await _context.TbCliente.AddAsync(tbCliente);
                await _context.SaveChangesAsync();

                Clientes cliente = _mapper.Map<Clientes>(entidade);

                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao adicionar o cliente. Ex: " + ex.Message);
            }
        }

        public async Task<Clientes> AtualizarCliente(TbCliente tbCliente)
        {
            try
            {
                TbCliente entidade = await _context.TbCliente.Where(x => x.IdCliente == tbCliente.IdCliente).AsNoTracking().FirstOrDefaultAsync();

                if (entidade == null)
                    return null;

                 _context.TbCliente.Update(tbCliente);
                await _context.SaveChangesAsync();

                Clientes cliente = _mapper.Map<Clientes>(entidade);

                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao atualizar o cliente. Ex: " + ex.Message);
            }
        }

        public async Task<bool> ExcluirCliente(long idCliente)
        {
            try
            {
                TbCliente entidade = await _context.TbCliente.Where(x => x.IdCliente == idCliente).AsNoTracking().FirstOrDefaultAsync();

                if (entidade == null)
                    return false;

                _context.TbCliente.Remove(entidade);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao atualizar o cliente. Ex: " + ex.Message);
            }
        }

        public async Task<Clientes> ObterClientesPorId(long idCliente)
        {
            try
            {
                TbCliente entidade = await _context.TbCliente.Where(x => x.IdCliente == idCliente).AsNoTracking().FirstOrDefaultAsync();

                if (entidade == null)
                    return null;

                Clientes cliente = _mapper.Map<Clientes>(entidade);

                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao buscar o cliente. Ex: " + ex.Message);
            }
        }

        public async Task<List<Clientes>> ObterTodosClientes()
        {
            try
            {
                List<TbCliente > entidade = await _context.TbCliente.AsNoTracking().ToListAsync();

                if (entidade == null || entidade.Count <= 0)
                    return null;

                List<Clientes> cliente = _mapper.Map<List<Clientes>>(entidade);

                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao buscar o cliente. Ex: " + ex.Message);
            }
        }
    }
}
