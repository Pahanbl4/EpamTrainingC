using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modell;

namespace DAL.Repository
{
    public class ProductRepository:VirtualRepository<Product>
    {
        public Product GetByTitle(string title)
        {
            using (var entity = new ModelDataEntities2())
            {
                return entity.Product.FirstOrDefault(m => m.ProductName == title);
            }
        }

        public Product GetEntityNameById(int id)
        {
            using (var entity = new ModelDataEntities2())
            {
                return entity.Product.FirstOrDefault(x => x.Id == id);

            }


        }

    }
}
