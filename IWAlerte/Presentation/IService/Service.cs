using Presentation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.IService
{
    public abstract class Service<T> : IService<T> where T : class
    {
        IUnitOfWork utk;
        protected Service(IUnitOfWork utk)
        {
            this.utk = utk;
        }
        public void Add(T entity)
        {
            utk.getRepository<T>().Add(entity);
        }

        public void Commit()
        {
            utk.Commit();
        }

        public void Delete(T entity)
        {
            utk.getRepository<T>().Delete(entity);
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
            utk.getRepository<T>().Delete(condition);
        }

        public void Dispose()
        {
            utk.Dispose();
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            return utk.getRepository<T>().Get(condition);
        }

        public T GetById(string id)
        {
            return utk.getRepository<T>().GetById(id);
        }

        public T GetById(long id)
        {
            return utk.getRepository<T>().GetById(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            return utk.getRepository<T>().GetMany(condition, orderBy);
        }

        public void Update(T entity)
        {
            utk.getRepository<T>().Update(entity);
        }
    }
}
