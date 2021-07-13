using Blog.Dominio.Entidades;

namespace Blog.Infraestrutura.Interfaces.Dominio.Base
{
    public interface IDominioRepositorio<T> : IRepositorioAsync<T> where T : Entidade
    {
        //Se for necessário adicionar novos metodos no futuro ao Repositorio
        //Basta criar uma nova interface e herda essa nova interface aqui.
        //Assim não seria preciso adicionar esta nova interface as abstrações do dominio,
        //uma vez que no dominio fazemos referencia ao IDomonioRepositorio.
    }
}
