using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_DAL.Interfaces
{
    public interface IRepository<T>
            where T : class, IEntity<int>
    {
        Task<T> CreateAsync(T model);
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        //Task<List<T>> GetAsync(Func<T, bool> predicate = null);
        List<T> GetAsync(Func<T, bool> predicate = null);
        void Delete(T model);
        void Edit(T model);
        Task SaveAsync();
        //IQueryable<T> Include(params Expression<Func<T, object>>[] includes);

        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
        params Expression<Func<T, object>>[] includeProperties);
        public void EditEntry(T model);



    }
}
