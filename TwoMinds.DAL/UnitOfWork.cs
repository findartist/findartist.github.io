using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace TwoMinds.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                var repository = new Repository<TEntity>(_context);
                _repositories.Add(type, repository);
            }

            return _repositories[type] as IRepository<TEntity>;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
