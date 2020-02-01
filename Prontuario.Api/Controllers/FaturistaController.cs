using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Service.Adapters;
using Prontuario.Service.Services;

namespace Prontuario.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/faturista")]
    public class FaturistaController : Controller
    {
        private readonly IFaturistaService _faturistaService;
        private readonly ILoggerService _loggerService;

        public FaturistaController(IFaturistaService faturistaService, ILoggerService loggerService)
        {
            _faturistaService = faturistaService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Metodo utilizado para inserir um faturista novo
        /// </summary>
        /// <param name="faturista">Objeto faturista</param>
        /// <returns>Ok ou NoContent</returns>
        [HttpPost("inserir")]
        public IActionResult Criar([FromBody] Faturista faturista)
        {
            try
            {
                var faturistaBody = faturista;
                var dataNascimento = DataAdapter.ParseDateTime(faturistaBody.Usuario.DataNascimentoString);
                faturistaBody.Usuario.DataNascimento = dataNascimento;

                var inserido = _faturistaService.Criar(faturistaBody);

                if (inserido)
                    return new OkResult();

                return new NoContentResult();
            }
            catch (ArgumentNullException ex)
            {
                _loggerService.Informar(ex);
                return NotFound();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para atualizar um faturista
        /// </summary>
        /// <param name="faturista"></param>
        /// <returns>Novo objeto modificado</returns>
        [HttpPost("atualizar")]
        public IActionResult Atualizar([FromBody] Faturista faturista)
        {
            try
            {
                var atualizado = _faturistaService.Atualizar(faturista);

                return new NoContentResult();
            }
            catch (ArgumentNullException ex)
            {
                _loggerService.Informar(ex);
                return NotFound();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para Deletar faturistas
        /// </summary>
        /// <param name="id">Id do faturista a ser deletado</param>
        /// <returns>ok result caso excluir</returns>
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var deletado = _faturistaService.Deletar(id);

                if (deletado)
                {
                    return new OkResult();
                }

                return new NoContentResult();

            }
            catch (ArgumentException ex)
            {
                _loggerService.Informar(ex);
                return NotFound();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo utilizado para buscar todos os faturistas
        /// </summary>
        /// <returns>Lista de faturistas com suas dependencias</returns>
        [HttpGet]
        public IActionResult BuscarTodosFaturistas()
        {
            try
            {
                var faturistas = _faturistaService.BuscarTodosFaturistas();

                if (faturistas != null)
                {
                    return new JsonResult(faturistas);
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
        /// Metodo responsavel por buscar o faturista pelo Id do mesmo
        /// </summary>
        /// <param name="id">Id do faturista</param>
        /// <returns>Entidade de faturista encontrada no banco</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarFaturistaPorId(int id)
        {
            try
            {
                var faturista = _faturistaService.BuscarFaturistaPorId(id);
                if (faturista.Id == 0) return new NoContentResult();

                return new JsonResult(faturista);

            }
            catch (ArgumentException ex)
            {
                _loggerService.Informar(ex);
                return NotFound();
            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }
    }
}
