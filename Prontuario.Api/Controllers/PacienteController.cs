using System;
using Microsoft.AspNetCore.Mvc;
using Prontuario.Domain.Entities;
using Prontuario.Service.Services;

namespace Prontuario.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/paciente")]
    public class PacienteController : Controller
    {
        private BaseService<Paciente> service = new BaseService<Paciente>();

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
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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