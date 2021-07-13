using Blog.Dominio.Entidades;
using Blog.Infraestrutura.Interfaces.Dominio.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestrutura.Dominio.Base
{
    public class DominioRepositorio<T> : RepositorioAsync<T>, IDominioRepositorio<T> where T : Entidade
    {
        protected DominioRepositorio(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
