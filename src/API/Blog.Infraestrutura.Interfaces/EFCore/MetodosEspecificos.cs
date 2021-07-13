using Blog.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Infraestrutura.Interfaces.EFCore
{
    public abstract class MetodosEspecificos<T> where T : Entidade
    {
        protected abstract IQueryable<T> GenerateQuery(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includeProperties);

        protected abstract IEnumerable<T> GetYieldManipulated(IEnumerable<T> entities, Func<T, T> DoAction);

    }
}
