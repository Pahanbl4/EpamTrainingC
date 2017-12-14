﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modell.UsersModel.Model
{
    public partial class SqlRepository
    {
        public IQueryable<UserRole> UserRoles
        {
            get
            {
                return Db.UserRole;
            }
        }

        public bool CreateUserRole(UserRole instance)
        {
            if (instance.IdUserRole == 0)
            {
                Db.UserRole.InsertOnSubmit(instance);
                Db.UserRole.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserRole(UserRole instance)
        {
            UserRole cache = Db.UserRole.Where(p => p.IdUserRole == instance.IdUserRole).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for UserRole
                Db.UserRole.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveUserRole(int idUserRole)
        {
            UserRole instance = Db.UserRole.Where(p => p.IdUserRole == idUserRole).FirstOrDefault();
            if (instance != null)
            {
                Db.UserRole.DeleteOnSubmit(instance);
                Db.UserRole.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
