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
        public IEnumerable<Models.SaleInfo> Items
        {
            get
            {
                var b = new List<DAL.Models.SaleInfo>();
                foreach (var a in this.managersContext.SaleInfo.Select(x => x))
                {
                    b.Add(ToObject(a));
                }

                return b;
            }
        }

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

        public Modell.SaleInfo GetEntityNameById(int id)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == id);
            return entity;
        }

        public void Remove(Models.SaleInfo item)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == item.ID_Sale);
            if (entity != null)
            {
                managersContext.SaleInfo.Remove(entity);
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

        public Models.SaleInfo ToObject(Modell.SaleInfo source)
        {
            return new DAL.Models.SaleInfo()
            {
                SaleDate = source.SaleDate,
                ID_Manager = source.ID_Manager,
                ID_Client = source.ID_Client,
                ID_Product = source.ID_Product
            };
        }

        public void Update(Models.SaleInfo item)
        {
            var entity = this.managersContext.SaleInfo.FirstOrDefault(x => x.ID_Sale == item.ID_Sale);
            if (entity != null)
            {
                entity.SaleDate = item.SaleDate;
                entity.ID_Manager = item.ID_Manager;
                entity.ID_Client = item.ID_Client;
                entity.ID_Product = item.ID_Product;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
