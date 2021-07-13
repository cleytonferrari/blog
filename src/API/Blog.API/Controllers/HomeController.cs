using Blog.Aplicacao.Interfaces.Dominio;
using Blog.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("v1/conta")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] Usuario model)
        {
            // Recupera o usuário
           // var usuario = UsuarioRepositorio.Get(model.Login, model.Senha);

            // Verifica se o usuário existe
            //if (usuario is null)
                return NotFound(new { mensagem = "Usuário ou senha inválidos" });

            // Gera o Token
            //var token = TokenServico.GerarToken(usuario);

            // Oculta a senha
            //usuario.Senha = "";

            // Retorna os dados
          //  return new
           // {
                //usuario,
                //token
           // };
        }

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo()
        {
            return "Anônimo";
        }

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado()
        {
            return $"Autenticado - {User.Identity.Name}";
        }

        [HttpGet]
        [Route("editor")]
        [Authorize(Roles = "editor,adm")]
        public string Editor()
        {
            return $"Editor: {User.Identity.Name}";
        }

        [HttpGet]
        [Route("administrador")]
        [Authorize(Roles = "adm")]
        public string Administrador()
        {
            return $"Administrador: {User.Identity.Name}";
        }
    }
}
