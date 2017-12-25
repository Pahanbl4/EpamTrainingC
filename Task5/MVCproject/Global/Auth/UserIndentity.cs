﻿using Modell.UsersModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVCproject.Global.Auth
{
    public class UserIndentity : IIdentity, IUserProvider
    {
        public User User { get; set; }
        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }
        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }
        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                return "anonym";
            }
        }
        public void Init(string email, IUserRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }
    }
}