using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Modell;

namespace DAL.Repository
{
    public class SaleInfoRepository : ContextRepository, IRepository<DAL.Models.SaleInfo, Modell.SaleInfo>
    {
       

        public void Add(Models.SaleInfo item)
        {
            var entity = this.ToEntity(item);
            managersContext.SaleInfo.Add(entity);
        }

        public Modell.SaleInfo GetEntity(Models.SaleInfo source)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == source.ID_Sale);
            return entity;
        }  

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }

        public Modell.SaleInfo ToEntity(Models.SaleInfo source)
        {
            return new Modell.SaleInfo()
            {
                SaleDate = source.SaleDate,
                ID_Manager = source.ID_Manager,
                ID_Client = source.ID_Client,
                ID_Product = source.ID_Product
            };
        }

      
       
    }
}
