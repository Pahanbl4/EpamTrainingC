﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Interfaces
{
   public interface IRepository<T>
    {
       IList<T> GetInfoList();
    }
}
