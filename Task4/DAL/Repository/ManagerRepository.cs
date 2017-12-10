using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Modell;

namespace DAL.Repository
{
    public class ManagerRepository : ContextRepository, IRepository<DAL.Models.Manager, Modell.Manager>
    {
       

        public void Add(Models.Manager item)
        {
            var entity = this.ToEntity(item);
            managersContext.Manager.Add(entity);
        }

        public Modell.Manager GetEntity(Models.Manager source)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ManagerName == source.ManagerName);
            return entity;
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }

        public Modell.Manager ToEntity(Models.Manager source)
        {
            return new Modell.Manager()
            {
                ManagerName = source.ManagerName
            };
        }

       
    }
}
