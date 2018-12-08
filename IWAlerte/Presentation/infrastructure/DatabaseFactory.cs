
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private IWContext dataContext;
        public IWContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new IWContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
      
    }

}
