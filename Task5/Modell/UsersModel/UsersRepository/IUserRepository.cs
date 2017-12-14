using Modell.UsersModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modell.UsersModel.Model
{
   public interface IUserRepository
    {
        #region User
        IQueryable<User> Users { get; }
        bool CreateUser(User instance);
        bool UpdateUser(User instance);
        bool RemoveUser(int idUser);
        User GetUser(string email);
        User Login(string email, string password);
        #endregion

        #region Roles
        IQueryable<Role> Roles { get; }
        bool CreateRole(Role instance);
        bool UpdateRole(Role instance);
        bool RemoveRole(int idRole);
        #endregion

        #region UserRoles
        IQueryable<UserRole> UserRoles { get; }
        bool CreateUserRole(UserRole instance);
        bool UpdateUserRole(UserRole instance);
        bool RemoveUserRole(int idUserRole);
        #endregion
    }
}
