using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Modell;

namespace DAL.Repository
{
    public class ProductRepository : ContextRepository, IRepository<DAL.Models.Product, Modell.Product>
    {
        public IEnumerable<Models.Product> Items
        {
            get
            {
                return this.managersContext.Product.Select(x => this.ToObject(x));
            }
        }

        public void Add(Models.Product item)
        {
            var entity = this.ToEntity(item);
            managersContext.Product.Add(entity);
        }

        public Modell.Product GetEntity(Models.Product source)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ProductName == source.ProductName && x.ProductCost == source.ProductCost);
            return entity;
        }

        public Modell.Product GetEntityNameById(int id)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == id);
            return entity;
        }

        public void Remove(Models.Product item)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (entity != null)
            {
                managersContext.Product.Remove(entity);
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

        public Modell.Product ToEntity(Models.Product source)
        {
            return new Modell.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        public Models.Product ToObject(Modell.Product source)
        {
            return new DAL.Models.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        public void Update(Models.Product item)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (entity != null)
            {
                entity.ProductName = item.ProductName;
                entity.ProductCost = item.ProductCost;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
