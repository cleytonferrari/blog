using Blog.Dominio.Entidades;
using Blog.Infraestrutura.ConfigBd.EFCore;
using Blog.Infraestrutura.Dominio.Base;
using Blog.Infraestrutura.Interfaces.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Infraestrutura.Dominio
{
    public class UsuarioRepositorio : DominioRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AplicacaoContexto dbContext) : base(dbContext)
        {

        }
        public async Task<Usuario> ObterPorLoginSenha(string login, string senha)
        {
            return await dbSet.Where(x => x.Login == login && x.Senha == senha).FirstOrDefaultAsync();
        }
    }
}
