using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TwoMinds.DAL
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task Commit();
    }
}
