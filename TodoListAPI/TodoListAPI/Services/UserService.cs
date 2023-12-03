using System.Collections.Generic;
using HelloWebApi.Interfaces.Services;
using HelloWebApi.Models;

namespace HelloWebApi.Services
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Super admin",
                    Email = "email@gmail.com"
                }
            };
        }
    }
}
