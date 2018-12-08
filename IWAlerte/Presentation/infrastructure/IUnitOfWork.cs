using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        RepositoryBase<T> getRepository<T>() where T : class;
    }

}
