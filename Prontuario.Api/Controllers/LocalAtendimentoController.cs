using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Services;

namespace Prontuario.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/local-atendimento")]
    public class LocalAtendimentoController : Controller
    {
        private readonly ILocalAtendimentoService _localAtendimentoService;
        private readonly ILoggerService _loggerService;

        public LocalAtendimentoController(ILocalAtendimentoService localAtendimentoService, ILoggerService loggerService)
        {
            _localAtendimentoService = localAtendimentoService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Metodo utilizado para inserir um paciente novo
        /// </summary>
        /// <param name="paciente">Objeto paciente</param>
        /// <returns>Ok ou NoContent</returns>
        [HttpPost("inserir")]
        public IActionResult Criar([FromBody] LocalAtendimento localAtendimento)
        {
            try
            {
                var inserido = _localAtendimentoService.Criar(localAtendimento);

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
        /// Metodo utilizado para atualizar um Paciente
        /// </summary>
        /// <param name="localAtendimento"></param>
        /// <returns>Novo objeto modificado</returns>
        [HttpPost("atualizar")]
        public IActionResult Atualizar([FromBody] LocalAtendimento localAtendimento)
        {
            try
            {
                var atualizado = _localAtendimentoService.Atualizar(localAtendimento);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para Deletar Pacientes
        /// </summary>
        /// <param name="id">Id do paciente a ser deletado</param>
        /// <returns>No content caso excluir</returns>
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var deletado = _localAtendimentoService.Deletar(id);

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
        /// Metodo utilizado para buscar todos os pacientes
        /// </summary>
        /// <returns>Lista de Pacientes com suas dependencias</returns>
        [HttpGet]
        public IActionResult BuscarTodosLocaisAtendimentos()
        {
            try
            {
                var locaisAtendimentos = _localAtendimentoService.BuscarTodosLocaisAtendimentos();

                if (locaisAtendimentos != null)
                {
                    return new JsonResult(locaisAtendimentos);
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
        /// Metodo responsavel por buscar o paciente pelo Id do mesmo
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Entidade de paciente encontrada no banco</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarLocalAtendimentoPorId(int id)
        {
            try
            {
                var localAtendimento = _localAtendimentoService.BuscarLocalAtendimentoPorId(id);
                if (localAtendimento.Id == 0) return new NoContentResult();

                return new JsonResult(localAtendimento);

            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }
    }
}
