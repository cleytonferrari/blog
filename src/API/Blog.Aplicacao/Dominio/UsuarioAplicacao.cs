using Blog.Aplicacao.Interfaces.Dominio;
using Blog.Dominio.Entidades;
using Blog.Infraestrutura.Interfaces.Dominio;
using System.Threading.Tasks;

namespace Blog.Aplicacao.Dominio
{
    public class UsuarioAplicacao : AplicacaoBase<Usuario>, IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioAplicacao(IUsuarioRepositorio repositorio):base(repositorio)
        {
            _repositorio = repositorio;
        }
        public Task<Usuario> ObterPorLoginSenha(string login, string senha)
        {
            //TODO: hash da senha
            return _repositorio.ObterPorLoginSenha(login, senha);
        }

        public override Task<Usuario> AdicionarAsync(Usuario entidade)
        {
            //entidade.Senha = //TODO: hash da senha
            return base.AdicionarAsync(entidade);
        }
    }
}
