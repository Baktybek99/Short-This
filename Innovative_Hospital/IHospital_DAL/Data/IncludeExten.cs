using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Innovative_Hospital_DAL.Data
{
    /// <summary>
    /// Статичный класс для методов расширения
    /// </summary>
    public static class IncludeExten
    {
        /// <summary>
        /// Чтоб инклужить данные из базы данных
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> IncludeExtension<TEntity>(this DbSet<TEntity> dbSet,
                                            params Expression<Func<TEntity, object>>[] includes)
                                            where TEntity : class
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }
            return query == null ? dbSet : query;
        }
    }
}
