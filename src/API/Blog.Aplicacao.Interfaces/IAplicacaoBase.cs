using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Aplicacao.Interfaces
{
    public interface IAplicacaoBase<T> where T : class
    {
        Task<T> AdicionarAsync(T entidade);
        Task AdicionarMuintosAsync(IEnumerable<T> entidades);

        Task<T> ObterPorIdAsync(object id);
        Task<IEnumerable<T>> ObterTodosAsync();

        Task AtualizarAsync(T entidade);
        Task AtualizarMuitosAsync(IEnumerable<T> entidades);

        Task<bool> RemoverAsync(object id);
        Task RemoverAsync(T entidade);
        Task RemoverMuitosAsync(IEnumerable<T> entidades);
    }
}
