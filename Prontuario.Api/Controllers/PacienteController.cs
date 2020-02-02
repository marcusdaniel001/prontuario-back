using System;
using Microsoft.AspNetCore.Mvc;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Service.Adapters;
using Prontuario.Service.Services;

namespace Prontuario.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/paciente")]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;
        private readonly ILoggerService _loggerService;

        public PacienteController(IPacienteService pacienteService, ILoggerService loggerService)
        {
            _pacienteService = pacienteService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Metodo utilizado para inserir um paciente novo
        /// </summary>
        /// <param name="paciente">Objeto paciente</param>
        /// <returns>Ok ou NoContent</returns>
        [HttpPost("inserir")]
        public IActionResult Criar([FromBody] Paciente paciente)
        {
            try
            {
                var pacienteBody = paciente;
                var dataNascimento = DataAdapter.ParseDateTime(pacienteBody.Usuario.DataNascimentoString);
                pacienteBody.Usuario.DataNascimento = dataNascimento;

                var inserido = _pacienteService.Criar(pacienteBody);

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
        /// <param name="paciente"></param>
        /// <returns>Novo objeto modificado</returns>
        [HttpPost("atualizar")]
        public IActionResult Atualizar([FromBody] Paciente paciente)
        {
            try
            {
                var atualizado = _pacienteService.Atualizar(paciente);

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
                var deletado = _pacienteService.Deletar(id);

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
        public IActionResult BuscarTodosPacientes()
        {
            try
            {
                var pacientes = _pacienteService.BuscarTodosPacientes();

                if (pacientes != null)
                {
                    return new JsonResult(pacientes);
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
        public IActionResult BuscarPacientePorId(int id)
        {
            try
            {
                var paciente = _pacienteService.BuscarPacientePorId(id);
                if(paciente.Id == 0) return new NoContentResult();

                return new JsonResult(paciente);

            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }
    }
}