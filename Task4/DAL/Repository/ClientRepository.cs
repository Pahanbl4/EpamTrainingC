using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Modell;

namespace DAL.Repository
{
    public class ClientRepository : ContextRepository, IRepository<DAL.Models.Client, Modell.Client>
    {

        public void Add(Models.Client item)
        {
            var entity = this.ToEntity(item);
            managersContext.Client.Add(entity);
        }

        public Modell.Client GetEntity(Models.Client source)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ClientName == source.ClientName);
            return entity;
        }
       
        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }

        public Modell.Client ToEntity(Models.Client source)
        {
            return new Modell.Client()
            {
                ClientName = source.ClientName
            };
        }
      
    }
}
