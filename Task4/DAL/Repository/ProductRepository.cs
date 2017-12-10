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
    }
}
