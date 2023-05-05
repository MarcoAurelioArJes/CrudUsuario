using CadastroDeUsuario.Models;
using CadastroDeUsuario.Repositorio;
using CadastroDeUsuario.Repositorio.ConexaoBancoDeDados;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeUsuario.Controllers
{
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(ContextoDaAplicacao  contextoDaAplicacao,
                                 IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost("api/[controller]/Criar")]
        public IActionResult Criar([FromBody] UsuarioModel usuario)
        {
            try
            {
                _usuarioRepositorio.Criar(usuario);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("api/[controller]/Atualizar/{id}")]
        public IActionResult Atualizar([FromBody] UsuarioModel usuarioAtualizado, int id)
        {
            try
            {
                _usuarioRepositorio.Atualizar(usuarioAtualizado, id);
                return Ok();
            }
            catch (Exception exception)
            {
                return  BadRequest(exception.Message);
            }
        }

        [HttpGet("api/[controller]/ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                return Ok(_usuarioRepositorio.ObterPorId(id));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("api/[controller]/ObterUsuarios")]
        public IActionResult ObterUsuarios()
        {
            try
            {
                return Ok(_usuarioRepositorio.ObterTodos());
            }
            catch (Exception exception)
            {
               return BadRequest(exception.Message);
            }
        }

        [HttpDelete("api/[controller]/Remover/{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _usuarioRepositorio.Remover(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
