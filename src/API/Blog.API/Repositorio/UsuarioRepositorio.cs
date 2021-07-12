using Blog.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog.API.Repositorio
{
    public class UsuarioRepositorio
    {
        public static Usuario Get(string login, string senha)
        {
            var bdUsuario = new List<Usuario>
            {
                new Usuario { Id = 1, Login = "cleyton", Senha = "171099", Permissao = "adm" },
                new Usuario { Id = 2, Login = "anderson", Senha = "123456", Permissao = "editor" }
            };
            return bdUsuario.FirstOrDefault(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha);
        }
    }
}
