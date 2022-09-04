using AutoMapper;
using MeAgendaAe.CamadaDados.Tabelas;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio.Dtos;
using MeAgendaAe.Dominio.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeAgendaAe.Controllers
{
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoRepositorio _repoAgendamento;
        private readonly IMapper _mapper;

        public AgendamentosController(IAgendamentoRepositorio agendamentoRepositorio, IMapper mapper)
        {
            _repoAgendamento = agendamentoRepositorio;
            _mapper = mapper;
        }

        [HttpGet("api/agendamentos/obterAgendamentoId/{idAgendamento}")]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObterAgendamentosPorId(long idAgendamento)
        {
            try
            {
                if (idAgendamento <= 0)
                    return BadRequest("O id de agendamento passado é nulo ou inválido.");

                Agendamentos agendamento = await _repoAgendamento.ObterAgendamentoPorId(idAgendamento);

                if (agendamento == null)
                    return NotFound($"Não foi encontrado nenhum agendamento com o Id: {idAgendamento} na base de dados");

                return Ok(agendamento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("api/agendamentos/obterTodosAgendamentos")]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObterTodosAgendamentos()
        {
            try
            {

                List<Agendamentos> agendamento = await _repoAgendamento.ObterTodosAgendamentos();

                if (agendamento == null || agendamento.Count <= 0)
                    return NotFound($"Não foi encontrado nenhum agendamento na base de dados");

                return Ok(agendamento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("api/agendamentos/criarAgendamento")]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CriarAgendamento(DtoAgendamento dtoAgendamento)
        {
            try
            {

                TbAgendamentos tbAgendamento = _mapper.Map<TbAgendamentos>(dtoAgendamento);
                Agendamentos agendamento = await _repoAgendamento.CriarAgendamento(tbAgendamento);

                if (agendamento == null)
                    return Problem($"Já existe um agendamento para esse mês, cancele o agendameno ativo para criar um novo. ");

                return Created($"api/agendamentos/obterAgendamentoId/{agendamento.IdAgendamento}", agendamento);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("api/agendamentos/atualizarAgendamento")]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> AtualizarAgendamento(DtoAgendamento dtoAgendamento)
        {
            try
            {
                if (dtoAgendamento == null)
                    return BadRequest("Objeto de agendamento a ser atualizado está nulo ou inválido");

                TbAgendamentos tbAgendamento = _mapper.Map<TbAgendamentos>(dtoAgendamento);
                Agendamentos agendamento = await _repoAgendamento.AtualizarAgendamentos(tbAgendamento);

                if (agendamento == null)
                    return NotFound($"Agendamento não localizado na base de dados para ser atualizado.");

                return Ok(agendamento);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("api/agendamentos/excluirAgendamento/{idAgendamento}")]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> ExcluirAgendamento(long idAgendamento)
        {
            try
            {

                if (idAgendamento == 0)
                    return BadRequest("Id de agendamento nulo ou inválido.");

                bool status = await _repoAgendamento.ExcluirAgendamento(idAgendamento);

                if (status == false)
                    return NotFound($"Agendamento não localizado na base de dados para ser excuido.");

                return Ok(status);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
