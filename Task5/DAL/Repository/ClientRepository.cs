using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modell;

namespace DAL.Repository
{
    public class ClientRepository :VirtualRepository<Client>
    {
       public Client GetByName(string name)
        {
            using (var entity = new ModelDataEntities2())
            {
                return entity.Client.FirstOrDefault(m => m.ClientName == name);
            }
        }

        public Client GetEntityNameById(int id)
        {
            using (var entity = new ModelDataEntities2())
            {
                return entity.Client.FirstOrDefault(x => x.Id == id);
                
            }
           
            
        }
    }
}
