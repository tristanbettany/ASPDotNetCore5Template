using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public interface IUserService
    {
        public void Add(User user);
        public User FindById(string userId);
    }
}
