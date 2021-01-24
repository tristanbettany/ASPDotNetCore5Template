using DataLayer;
using DataLayer.Entities;
using System;
using System.Linq;

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
            User existingUser = FindById(user.Id);
            if (existingUser == default(User))
            {
                DataLayerContext.Add(user);
                DataLayerContext.SaveChanges();
            }
        }

        public User FindById(string userId)
        {
            return DataLayerContext.Users.FirstOrDefault(row => row.Id == userId);
        }
    }
}
