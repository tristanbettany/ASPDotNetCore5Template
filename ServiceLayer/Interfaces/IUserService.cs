using DataLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        public void Add(User user);
        public User FindById(string userId);
    }
}
