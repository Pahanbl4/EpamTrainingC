using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modell;

namespace DAL.Repository
{
    public class ManagerRepository :VirtualRepository<Manager>
    {
        public Manager GetByName(string name)
        {
            using (var entity = new ModelDataEntities2())
            {
                return entity.Manager.FirstOrDefault(m => m.ManagerName == name);
            }
        }

        public decimal GetSumById(int id)
        {
            using (var context = new ModelDataEntities2())
            {
                return context.Manager.FirstOrDefault(m => m.Id == id).SaleInfo.Sum(x => x.Sum);
            }
        }

        public IEnumerable<SaleInfo> GetSalesByManagerId(int id)
        {
            using (var context = new ModelDataEntities2())
            {
                return context.Manager.FirstOrDefault(m => m.Id == id).SaleInfo.ToList();
            }
        }

      
    }
}
