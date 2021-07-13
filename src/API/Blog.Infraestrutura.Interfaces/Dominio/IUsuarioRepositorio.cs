using Blog.Dominio.Entidades;
using Blog.Infraestrutura.Interfaces.Dominio.Base;
using System.Threading.Tasks;

namespace Blog.Infraestrutura.Interfaces.Dominio
{
    public interface IUsuarioRepositorio:IDominioRepositorio<Usuario>
    {
        Task<Usuario> ObterPorLoginSenha(string login, string senha);
    }
}
