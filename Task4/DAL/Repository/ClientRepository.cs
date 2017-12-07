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
        public IEnumerable<Models.Client> Items
        {
            get
            {
                return this.managersContext.Client.Select(x => this.ToObject(x));
            }
        }

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

        public Modell.Client GetEntityNameById(int id)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == id);
            return entity;
        }

        public void Remove(Models.Client item)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
            if (entity != null)
            {
                managersContext.Client.Remove(entity);
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

        public Modell.Client ToEntity(Models.Client source)
        {
            return new Modell.Client()
            {
                ClientName = source.ClientName
            };
        }

        public Models.Client ToObject(Modell.Client source)
        {
            return new DAL.Models.Client()
            {
                ClientName = source.ClientName
            };
        }

        public void Update(Models.Client item)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
            if (entity != null)
            {
                entity.ClientName = item.ClientName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
