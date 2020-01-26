using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Service.Adapters;
using Prontuario.Service.Services;

namespace Prontuario.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/paciente")]
    public class PacienteController : Controller
    {
        private BaseService<Paciente> service = new BaseService<Paciente>();
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        /// <summary>
        /// Metodo utilizado para inserir um paciente novo
        /// </summary>
        /// <param name="paciente">Objeto paciente</param>
        /// <returns>Ok ou NoContent</returns>
        [HttpPost("inserir")]
        public IActionResult Post([FromBody] Paciente paciente)
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
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("---------------- Mensagem ----------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine("---------------- StackTrace ----------------");
                Console.WriteLine(ex.StackTrace);

                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------- Mensagem ----------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine("---------------- StackTrace ----------------");
                Console.WriteLine(ex.StackTrace);

                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para atualizar um Paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns>Novo objeto modificado</returns>
        [HttpPost("atualizar")]
        public IActionResult Put([FromBody] Paciente paciente)
        {
            try
            {
                service.Put<Paciente>(paciente);

                return new ObjectResult(paciente);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Metodo utilizado para Deletar Pacientes
        /// </summary>
        /// <param name="id">Id do paciente a ser deletado</param>
        /// <returns>No content caso excluir</returns>
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
                return BadRequest(ex);
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
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}