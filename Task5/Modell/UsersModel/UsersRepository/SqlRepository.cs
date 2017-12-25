using Modell.UsersModel.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modell.UsersModel.Model
{
   public partial class SqlRepository:IUserRepository
    {

       [Inject]
       public UserDataDataContext Db { get; set; }
    }
}
