using System.Collections.Generic;
using TodoListAPI.Models;

namespace TodoListAPI.Interfaces.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
