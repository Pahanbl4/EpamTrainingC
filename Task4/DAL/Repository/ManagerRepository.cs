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
        public IEnumerable<Models.Manager> Items
        {
            get
            {
                var b = new List<DAL.Models.Manager>();
                foreach (var a in this.managersContext.Manager.Select(x => x))
                {
                    b.Add(ToObject(a));
                }

                return b;
            }
        }

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

        public Modell.Manager GetEntityNameById(int id)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ID_Manager == id);
            return entity;
        }

        public void Remove(Models.Manager item)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ID_Manager == item.ID_Manager);
            if (entity != null)
            {
                managersContext.Manager.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
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

        public Models.Manager ToObject(Modell.Manager source)
        {
            return new DAL.Models.Manager()
            {
                ManagerName = source.ManagerName
            };
        }

        public void Update(Models.Manager item)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ManagerName == item.ManagerName);
            if (entity != null)
            {
                entity.ManagerName = item.ManagerName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
