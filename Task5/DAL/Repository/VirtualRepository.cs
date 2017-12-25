using Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class VirtualRepository<T> where T : class, IEntity
    {
        protected ModelDataEntities2 managersContext;
        public IEnumerable<T> GetById(int id)
        {
            using (var entity = new ModelDataEntities2())
            {
                return entity.Set<T>().Where(x => x.Id == id).ToList();
            }
        }

       

        public int Insert(T item)
        {
            using (var context = new ModelDataEntities2())
            {
                var entity = context.Set<T>().Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = new ModelDataEntities2())
            {
                var entity = context.Set<T>().ToList();
                return entity;
            }
        }

        public void Remove(T item)
        {
            using (var context = new ModelDataEntities2())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (var context = new ModelDataEntities2())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
