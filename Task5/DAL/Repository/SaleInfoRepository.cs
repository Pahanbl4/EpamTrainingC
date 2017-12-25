using Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SaleInfoRepository : VirtualRepository<SaleInfo>
    {
        protected ModelDataEntities2 managersContext;

        Modell.SaleInfo ToObject(Modell.SaleInfo source)
        {
            return new Modell.SaleInfo()
            {
                Dato = source.Dato,
                ID_Manager = source.ID_Manager,
                ID_Client = source.ID_Client,
                ID_Product = source.ID_Product
            };
        }

        public IEnumerable<Modell.SaleInfo> Items
        {
            get
            {
                var b = new List<Modell.SaleInfo>();
                foreach (var a in this.managersContext.SaleInfo.Select(x => x))
                {
                    b.Add(ToObject(a));
                }

                return b;
                //return this.managersContext.SaleInfo.Select(x => this.ToObject(x));
            }
        }

        public SaleInfo GetEntityNameById(int id)
        {
            using (var entity = new ModelDataEntities2())
            {
                return entity.SaleInfo.FirstOrDefault(x => x.Id == id);

            }


        }

    }
}
