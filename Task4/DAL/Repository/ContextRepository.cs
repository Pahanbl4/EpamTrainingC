using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modell;

namespace DAL.Repository
{
   public class ContextRepository : IDisposable
    {
        protected ModelDataEntities managersContext;
        public ContextRepository()
        {
            managersContext = new ModelDataEntities();
        }
        public void Dispose()
        {
            managersContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
