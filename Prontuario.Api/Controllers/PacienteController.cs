using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public PacienteController(IPacienteService pacienteService, ILogger<PacienteController> logger)
        {
            _pacienteService = pacienteService;
            _logger = logger;
        }

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
                _logger.LogInformation(ex.Message);
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

        [HttpPost("atualizar")]
        public IActionResult Put([FromBody] Paciente item)
        {
            try
            {
                service.Put<Paciente>(item);

                return new ObjectResult(item);
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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
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