﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modell.UsersModel.Model
{
    public partial class SqlRepository
    {
        public IQueryable<User> Users
        {
            get
            {
                return Db.User;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.IdUser == 0)
            {
                instance.DateAdded = DateTime.Now;
                instance.ActivatedLink = User.GetActivateUrl();
                Db.User.InsertOnSubmit(instance);
                Db.User.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = Db.User.Where(p => p.IdUser == instance.IdUser).FirstOrDefault();
            if (cache != null)
            {
                cache.BirthDate = instance.BirthDate;
                cache.AvatarPath = instance.AvatarPath;
                cache.Email = instance.Email;
                Db.User.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveUser(int idUser)
        {
            User instance = Db.User.Where(p => p.IdUser == idUser).FirstOrDefault();
            if (instance != null)
            {
                Db.User.DeleteOnSubmit(instance);
                Db.User.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public User GetUser(string email)
        {
            return Db.User.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            return Db.User.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }
    }
}
