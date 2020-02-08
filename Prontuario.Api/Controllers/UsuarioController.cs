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
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILoggerService _loggerService;

        public UsuarioController(IUsuarioService usuarioService, ILoggerService loggerService)
        {
            _usuarioService = usuarioService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Metodo utilizado para inserir uma secretaria nova
        /// </summary>
        /// <param name="secretaria">Objeto secretaria</param>
        /// <returns>Ok ou NoContent</returns>
        [HttpPost("inserir")]
        public IActionResult Criar([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioBody = usuario;
                var dataNascimento = DataAdapter.ParseDateTime(usuarioBody.DataNascimentoString);
                usuarioBody.DataNascimento = dataNascimento;

                var inserido = _usuarioService.Criar(usuarioBody);

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
        public IActionResult Atualizar([FromBody] Usuario usuario)
        {
            try
            {
                var atualizado = _usuarioService.Atualizar(usuario);

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
                var deletado = _usuarioService.Deletar(id);

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
        public IActionResult BuscarTodosUsuarios()
        {
            try
            {
                var usuarios = _usuarioService.BuscarTodosUsuarios();

                if (usuarios != null)
                {
                    return new JsonResult(usuarios);
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
        public IActionResult BuscarUsuarioPorId(int id)
        {
            try
            {
                var usuario = _usuarioService.BuscarUsuarioPorId(id);
                if (usuario.Id == 0) return new NoContentResult();

                return new JsonResult(usuario);

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
        /// <param name="cpf">Id da secretaria</param>
        /// <returns>Entidade de secretaria encontrada no banco</returns>
        [HttpGet("por-cpf/{cpf}")]
        public IActionResult BuscarUsuarioPorCpf(string cpf)
        {
            try
            {
                var usuario = _usuarioService.BuscarUsuarioPorCpf(cpf);
                if (usuario.Id == 0) return new NoContentResult();

                return new JsonResult(usuario);

            }
            catch (Exception ex)
            {
                _loggerService.Informar(ex);
                return BadRequest();
            }
        }
    }
}
