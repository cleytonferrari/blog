using Blog.Dominio.Entidades;
using System.Threading.Tasks;

namespace Blog.Aplicacao.Interfaces.Dominio
{
    public interface IUsuarioAplicacao: IAplicacaoBase<Usuario>
    {
        Task<Usuario> ObterPorLoginSenha(string login, string senha);
    }
}
