using DataLayer;
using DataLayer.Entities;
using System;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        private DataLayerContext DataLayerContext;

        public UserService(DataLayerContext context)
        {
            DataLayerContext = context;
        }

        public void Add(User user)
        {
            DataLayerContext.Add(user);
            DataLayerContext.SaveChanges();
        }
    }
}
