﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface IRepository<Dal, Model>
    {
        void Add(Dal item);
        void Remove(Dal item);
        void Update(Dal item);
        Model GetEntityNameById(int id);
        Model GetEntityIDByName(string name);
        Model GetEntity(Dal source);
        Model ToEntity(Dal source);
        Dal ToObject(Model source);
        IEnumerable<Dal> Items { get; }
        void SaveChanges();
    }
}
