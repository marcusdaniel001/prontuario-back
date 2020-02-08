using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Service.Adapters;

namespace Prontuario.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/agenda")]
    public class AgendaController : Controller
    {
        private readonly IAgendaService _agendaService;
        private readonly ILoggerService _loggerService;

        public AgendaController(IAgendaService agendaService, ILoggerService loggerService)
        {
            _agendaService = agendaService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Metodo utilizado para inserir uma secretaria nova
        /// </summary>
        /// <param name="agenda">Objeto secretaria</param>
        /// <returns>Ok ou NoContent</returns>
        [HttpPost("inserir")]
        public IActionResult Criar([FromBody] Agenda agenda)
        {
            try
            {
                var agendaBody = agenda;

                var dataInicio = DataAdapter.ParseDateTime(agendaBody.InicioString);
                agendaBody.Inicio = dataInicio;

                var dataFim = DataAdapter.ParseDateTime(agendaBody.FimString);
                agendaBody.Fim = dataFim;

                var inserido = _agendaService.Criar(agendaBody);

                if (inserido)
                    return new OkResult();

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para atualizar um secretaria
        /// </summary>
        /// <param name="secretaria"></param>
        /// <returns>Novo objeto modificado</returns>
        [HttpPost("atualizar")]
        public IActionResult Atualizar([FromBody] Agenda agenda)
        {
            try
            {
                var atualizado = _agendaService.Atualizar(agenda);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para Deletar secretaria
        /// </summary>
        /// <param name="id">Id da secretaria a ser deletado</param>
        /// <returns>ok result caso excluir</returns>
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var deletado = _agendaService.Deletar(id);

                if (deletado)
                {
                    return new OkResult();
                }

                return new NoContentResult();

            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para buscar todas as secretarias
        /// </summary>
        /// <returns>Lista de secretarias com suas dependencias</returns>
        [HttpGet]
        public IActionResult BuscarTodasAgendas()
        {
            try
            {
                var agendas = _agendaService.BuscarTodasAgendas();

                if (agendas != null)
                {
                    return new JsonResult(agendas);
                }

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar a secretaria pelo Id do mesmo
        /// </summary>
        /// <param name="id">Id da secretaria</param>
        /// <returns>Entidade de secretaria encontrada no banco</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarAgendaPorId(int id)
        {
            try
            {
                var agenda = _agendaService.BuscarAgendaPorId(id);
                if (agenda.Id == 0) return new NoContentResult();

                return new JsonResult(agenda);

            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }
    }
}
