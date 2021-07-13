using Blog.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Infraestrutura.Interfaces
{
    public interface IRepositorioAsync<T> : IDisposable where T : Entidade
    {
        Task<T> AdicionarSync(T entidade);
        Task<int> AdicionarMuitosAsync(IEnumerable<T> entidades);

        Task<T> ObterPorIdAsync(object id);
        Task<IEnumerable<T>> ObterTodosAsync();

        Task<int> AtualizarAsync(T entidade);
        Task<int> AtualizarMuitosAsync(IEnumerable<T> entidades);

        Task<bool> RemoverAsync(object id);
        Task<int> RemoverAsync(T entidade);
        Task<int> RemoverMuitosAsync(IEnumerable<T> entidades);

        //TODO: Separar em Interfaces (Ler, Gravar e Excluir)
    }
}
