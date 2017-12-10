using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface IRepository<Dal, Model>
    {
        void Add(Dal item);
        Model GetEntity(Dal source);
        Model ToEntity(Dal source);
        void SaveChanges();
    }
}
