using Blog.Dominio.Entidades;
using Blog.Infraestrutura.Interfaces;
using Blog.Infraestrutura.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Infraestrutura
{
    public class RepositorioAsync<T> : MetodosEspecificos<T>, IRepositorioAsync<T> where T : Entidade
    {

        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public RepositorioAsync(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        public virtual async Task<int> AdicionarMuitosAsync(IEnumerable<T> entidades)
        {
            await dbSet.AddRangeAsync(entidades);
            return await CommitAsync();
        }

        public virtual async Task<T> AdicionarSync(T entidade)
        {
            var r = await dbSet.AddAsync(entidade);
            await CommitAsync();
            return r.Entity;
        }

        public virtual async Task<int> AtualizarAsync(T entidade)
        {
            dbContext.Entry(entidade).State = EntityState.Modified;
            return await CommitAsync();
        }

        public virtual async Task<int> AtualizarMuitosAsync(IEnumerable<T> entidades)
        {
            dbSet.UpdateRange(entidades);
            return await CommitAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<T> ObterPorIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await Task.FromResult(dbSet);
        }

        public virtual async Task<bool> RemoverAsync(object id)
        {
            T entidade = await ObterPorIdAsync(id);

            if (entidade == null) return false;

            return await RemoverAsync(entidade) > 0 ? true : false;
        }

        public virtual async Task<int> RemoverAsync(T entidade)
        {
            dbSet.Remove(entidade);
            return await CommitAsync();
        }

        public virtual async Task<int> RemoverMuitosAsync(IEnumerable<T> entidades)
        {
            dbSet.RemoveRange(entidades);
            return await CommitAsync();
        }
        private async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        protected override IQueryable<T> GenerateQuery(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            query = GenerateQueryableWhereExpression(query, filter);
            query = GenerateIncludeProperties(query, includeProperties);

            if (orderBy != null)
                return orderBy(query);

            return query;
        }

        private IQueryable<T> GenerateQueryableWhereExpression(IQueryable<T> query,
        Expression<Func<T, bool>> filter)
        {
            if (filter != null)
                return query.Where(filter);

            return query;
        }

        private IQueryable<T> GenerateIncludeProperties(IQueryable<T> query, params string[] includeProperties)
        {
            foreach (string includeProperty in includeProperties)
                query = query.Include(includeProperty);

            return query;
        }

        protected override IEnumerable<T> GetYieldManipulated(IEnumerable<T> entities, Func<T, T> DoAction)
        {
            foreach (var e in entities)
            {
                yield return DoAction(e);
            }
        }

        
    }
}
