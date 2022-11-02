using AutoMapper;
using MeAgendaAe.CamadaDadosAcesso.Interfaces;
using MeAgendaAe.Dominio.Dtos;
using MeAgendaAe.Dominio.Entidades;
using MeAgendaAe.Dominio.Interfaces;
using MeAgendaAe.Dominio.Model;
using MeAgendaAe.Dominio.ViewModel.Agendamentos.Entrada;
using MeAgendaAe.RegrasDeNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeAgendaAe.Controllers
{
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentosServices _agendamentoService;
        private readonly IMapper _mapper;

        public AgendamentosController(IAgendamentosServices agendamentoService, IMapper mapper)
        {
            _agendamentoService = agendamentoService;
            _mapper = mapper;
        }

        [HttpGet("api/agendamentos/obterAgendamentoId/{idAgendamento}")]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Agendamentos), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ObterAgendamentosPorId(Guid idAgendamento, CancellationToken cancellationToken)
        {
            try
            {
                if (idAgendamento == Guid.Empty)
                    return BadRequest("O id de agendamento passado é nulo ou inválido.");

                Agendamentos agendamento = await _agendamentoService.ObterAgendamentoPeloId(idAgendamento, cancellationToken);

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

        public async Task<IActionResult> ObterTodosAgendamentos(AgendamentsRequestQueryModel request, CancellationToken cancellationToken)
        {
            try
            {

                var agendamento = await _agendamentoService.ObterTodos(request, cancellationToken);
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

        public async Task<IActionResult> CriarAgendamento(DtoAgendamento dtoAgendamento, CancellationToken cancellationToken)
        {
            try
            {

                TbAgendamentos tbAgendamento = _mapper.Map<TbAgendamentos>(dtoAgendamento);
                Agendamentos agendamento = await _agendamentoService.NovoAgendamento(tbAgendamento, cancellationToken);

                if (agendamento == null)
                    return Problem($"Já existe um agendamento para esse mês, cancele o agendameno ativo para criar um novo. ");

                return Created($"api/agendamentos/obterAgendamentoId/{agendamento.Id}", agendamento);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("api/agendamentos/cancelarAgendamento")]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> AtualizarAgendamento(CancelarAgendamentoRequestViewModel request, CancellationToken cancellation)
        {
            try
            {
                if (request == null)
                    return BadRequest("Objeto de agendamento a ser atualizado está nulo ou inválido");

                Agendamentos agendamento = await _agendamentoService.CancelarAgendamento(request, cancellation);

                if (agendamento == null)
                    return NotFound($"Agendamento não localizado na base de dados para ser atualizado.");

                return Ok(agendamento);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("api/agendamentos/finalizarAgendamento/{idAgendamento}")]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<Agendamentos>), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> FinalizarAgendamento(Guid idAgendamento, CancellationToken cancellationToken)
        {
            try
            { 

                if (idAgendamento == Guid.Empty)
                    return BadRequest("Id de agendamento nulo ou inválido.");

                var agendamentos = await _agendamentoService.FinalizarAgendamento(idAgendamento, cancellationToken);

                return Ok(agendamentos);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
