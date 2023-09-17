using Innovative_Hospital_DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_DAL.Data
{
    /// <summary>
    /// Класс в котором мы можем достать любой репозитоий
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IHospitalDbContext _context;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public UnitOfWork(IHospitalDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        /// <summary>
        /// Для получения определенного репозитория
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> GetRepository<T>()
            where T : class, IEntity<int>
        {
            return _repositories.GetOrAdd(typeof(T), new Repository<T>(_context)) as IRepository<T>;
        }


        public IRepositoryUser<T> GetRepositoryUser<T>()
           where T : IdentityUser
        {
            return _repositories.GetOrAdd(typeof(T), new RespositoryUser<T>(_context)) as IRepositoryUser<T>;
        }


    }
}
