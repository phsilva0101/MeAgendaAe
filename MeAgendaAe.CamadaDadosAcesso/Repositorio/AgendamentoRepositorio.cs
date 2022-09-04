using AutoMapper;
using MeAgendaAe.CamadaDados.Context;
using MeAgendaAe.CamadaDados.Tabelas;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio;
using MeAgendaAe.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeAgendaAe.CamadaDadosAcesso.Repositorio
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly MeAgendaAeContext _context;
        private IMapper _mapper;
        public AgendamentoRepositorio(MeAgendaAeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Agendamentos> ObterAgendamentoPorId(long id)
        {
            try
            {
                TbAgendamentos agendamento = await _context.TbAgendamentos.Where(x => x.IdAgendamento == id).AsNoTracking().FirstOrDefaultAsync();

                if (agendamento == null)
                    return null;

                Agendamentos agendamentoModel = _mapper.Map<Agendamentos>(agendamento);
                return agendamentoModel;
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu um erro ao buscar o agendamento de id: {id}. Ex: {ex.Message}");
            }
        }

        public async Task<List<Agendamentos>> ObterTodosAgendamentos()
        {
            try
            {
                List<TbAgendamentos> agendamento = await _context.TbAgendamentos.AsNoTracking().ToListAsync();

                if (agendamento == null || agendamento.Count <= 0)
                    return null;

                List<Agendamentos> agendamentoModel = _mapper.Map<List<Agendamentos>>(agendamento);
                return agendamentoModel;
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu um erro ao buscar os agendamentos. Ex: {ex.Message}");
            }
        }

        public async Task<Agendamentos> AtualizarAgendamentos(TbAgendamentos tbAgendamentos)
        {
            try
            {
                TbAgendamentos agendamento = await _context.TbAgendamentos.Where(x => x.IdAgendamento == tbAgendamentos.IdAgendamento).AsNoTracking().FirstOrDefaultAsync();

                if (agendamento == null)
                    return null;

                _context.TbAgendamentos.Update(tbAgendamentos);
                await _context.SaveChangesAsync();

                Agendamentos agendamentoModel = _mapper.Map<Agendamentos>(agendamento);

                return agendamentoModel;


            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu um erro ao tentar atuaizar o agendamento de id: {tbAgendamentos.IdAgendamento}. Ex: {ex.Message}");
            }
        }

        public async Task<Agendamentos> CriarAgendamento(TbAgendamentos tbAgendamentos)
        {
            try
            {
                int mesDataAtual = DateTime.Now.Month;
                int mesDataAgendamento = tbAgendamentos.DataAgendamento.Month;
                TbCliente tbCliente = null;

                TbAgendamentos agendamento = await _context.TbAgendamentos.Where(x => x.DataAgendamento.Month == tbAgendamentos.DataAgendamento.Month && x.IdCliente == tbAgendamentos.IdCliente && x.IdStatusAgendamento == (long)EnumStatusAgendamento.Agendado).AsNoTracking().FirstOrDefaultAsync();

                if (agendamento != null)
                    return null;

                await _context.TbAgendamentos.AddAsync(tbAgendamentos);
                var result = await _context.SaveChangesAsync();

                Agendamentos agendamentoModel = _mapper.Map<Agendamentos>(agendamento);

                return agendamentoModel;


            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu um erro ao tentar atuaizar o agendamento de id: {tbAgendamentos.IdAgendamento}. Ex: {ex.Message}");
            }
        }

        public async Task<bool> ExcluirAgendamento(long id)
        {
            try
            {
                TbAgendamentos agendamento = await _context.TbAgendamentos.Where(x => x.IdAgendamento == id).AsNoTracking().FirstOrDefaultAsync();

                if (agendamento == null)
                    return false;

                _context.TbAgendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu um erro ao tentar excluir o agendamento de ID: {id}. Ex: {ex.Message}");
            }
        }

        public async Task<bool> FinalizarAgendamento(long id)
        {
            try
            {
                TbCliente tbCliente = null;

                TbAgendamentos agendamento = await _context.TbAgendamentos.Where(x => x.IdAgendamento == id).AsNoTracking().FirstOrDefaultAsync();

                if (agendamento == null)
                    return false;

                agendamento.IdStatusAgendamento = (long) EnumStatusAgendamento.Finalizado;

                _context.TbAgendamentos.Update(agendamento);
                var result = await _context.SaveChangesAsync();

                if(result > 0)
                {
                    tbCliente =  await _context.TbCliente.Where(x => x.IdCliente == agendamento.IdCliente).AsNoTracking().FirstOrDefaultAsync();
                    tbCliente.QtdVisitas += 1;

                    _context.TbCliente.Update(tbCliente);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu um erro ao tentar excluir o agendamento de ID: {id}. Ex: {ex.Message}");
            }
        }
    }
}
