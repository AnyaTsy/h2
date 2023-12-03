using System.Collections.Generic;
using TodoListAPI.Models;

namespace TodoListAPI.Interfaces.Repositories
{
    public interface ITodoTaskRepository
    {
        List<TodoTask> GetTasks();

        int GetTasksTotalCount();

        TodoTask GetTaskById(int id);

        TodoTask AddTask(TodoTask task);

        void DeleteTask(int id);
    }
}
