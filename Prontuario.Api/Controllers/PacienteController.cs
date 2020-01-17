using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces;
using Prontuario.Service.Services;

namespace Prontuario.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/paciente")]
    public class PacienteController : Controller
    {
        private BaseService<Paciente> service = new BaseService<Paciente>();
        private readonly ILoggerService _loggerService;

        public PacienteController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        [HttpPost("inserir")]
        public IActionResult Post([FromBody] Paciente item)
        {
            try
            {

                service.Post<Paciente>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                _loggerService.Informar(ex.Message, ex.StackTrace);

                return NotFound();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex.Message, ex.StackTrace);

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