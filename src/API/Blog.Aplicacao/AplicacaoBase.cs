using Blog.Aplicacao.Interfaces;
using Blog.Dominio.Entidades;
using Blog.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Aplicacao
{
    public class AplicacaoBase<T> : IAplicacaoBase<T> where T : Entidade
    {
        protected readonly IRepositorioAsync<T> repositorio;
        public AplicacaoBase(IRepositorioAsync<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        public virtual async Task<T> AdicionarAsync(T entidade)
        {
            return await repositorio.AdicionarSync(entidade);
        }

        public virtual async Task AdicionarMuintosAsync(IEnumerable<T> entidades)
        {
            await repositorio.AdicionarMuitosAsync(entidades);
        }

        public virtual async Task AtualizarAsync(T entidade)
        {
            await repositorio.AtualizarAsync(entidade);
        }

        public virtual async Task AtualizarMuitosAsync(IEnumerable<T> entidades)
        {
            await repositorio.AtualizarMuitosAsync(entidades);
        }

        public virtual async Task<T> ObterPorIdAsync(object id)
        {
            return await repositorio.ObterPorIdAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await repositorio.ObterTodosAsync();
        }

        public virtual async Task<bool> RemoverAsync(object id)
        {
            return await repositorio.RemoverAsync(id);
        }

        public virtual async Task RemoverAsync(T entidade)
        {
            await repositorio.RemoverAsync(entidade);
        }

        public virtual async Task RemoverMuitosAsync(IEnumerable<T> entidades)
        {
            await repositorio.RemoverAsync(entidades);
        }
    }
}
