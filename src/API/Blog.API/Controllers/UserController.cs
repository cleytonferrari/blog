using Blog.Aplicacao.Interfaces.Dominio;
using Blog.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("v1/usuario")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;
        public UserController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpPost]
        [Route("adicionar")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> Add([FromBody] Usuario model)
        {
            await _usuarioAplicacao.AdicionarAsync(model);

            return Ok();
        }

        [HttpGet]
        [Route("listar")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Usuario>>> Listar()
        {
            var retorno = await _usuarioAplicacao.ObterTodosAsync();

            return Ok(retorno);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> Listar(int id)
        {
            var retorno = await _usuarioAplicacao.ObterPorIdAsync(id);
            if (retorno is null)
                return NotFound();

            return Ok(retorno);
        }

        [HttpDelete]
        [Route("remover/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Remover(int id)
        {
            var retorno = await _usuarioAplicacao.ObterPorIdAsync(id);
            if (retorno is null)
                return NotFound();

            await _usuarioAplicacao.RemoverAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Usuario model)
        {
           
            await _usuarioAplicacao.AtualizarAsync(model);
            return Ok();
        }
    }
}
