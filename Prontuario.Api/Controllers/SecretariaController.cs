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
    [Route("api/secretaria")]
    public class SecretariaController : Controller
    {
        private readonly ISecretariaService _secretariaService;
        private readonly ILoggerService _loggerService;

        public SecretariaController(ISecretariaService secretariaService, ILoggerService loggerService)
        {
            _secretariaService = secretariaService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Metodo utilizado para inserir uma secretaria nova
        /// </summary>
        /// <param name="secretaria">Objeto secretaria</param>
        /// <returns>Ok ou NoContent</returns>
        [HttpPost("inserir")]
        public IActionResult Criar([FromBody] Secretaria secretaria)
        {
            try
            {
                var secretariaBody = secretaria;
                var dataNascimento = DataAdapter.ParseDateTime(secretariaBody.Usuario.DataNascimentoString);
                secretariaBody.Usuario.DataNascimento = dataNascimento;

                var inserido = _secretariaService.Criar(secretariaBody);

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
        public IActionResult Atualizar([FromBody] Secretaria secretaria)
        {
            try
            {
                var atualizado = _secretariaService.Atualizar(secretaria);

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
                var deletado = _secretariaService.Deletar(id);

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
        public IActionResult BuscarTodasSecretarias()
        {
            try
            {
                var secretarias = _secretariaService.BuscarTodasSecretarias();

                if (secretarias != null)
                {
                    return new JsonResult(secretarias);
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
        public IActionResult BuscarSecretariaPorId(int id)
        {
            try
            {
                var secretaria = _secretariaService.BuscarSecretariaPorId(id);
                if (secretaria.Id == 0) return new NoContentResult();

                return new JsonResult(secretaria);

            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }
    }
}
