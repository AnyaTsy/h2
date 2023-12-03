using System.Collections.Generic;
using System.Linq;
using TodoListAPI.Enums;
using TodoListAPI.Interfaces.Repositories;
using TodoListAPI.Models;

namespace TodoListAPI.Repositories
{
    public class FakeTodoTaskRepository : ITodoTaskRepository
    {
        private readonly List<TodoTask> _tasks = new List<TodoTask>
        {
            new TodoTask
            {
                TaskId = 1,
                Title = "Task 1",
                Type = TaskType.Generic
            },
            new TodoTask
            {
                TaskId = 2,
                Title = "Task 2",
                Type = TaskType.Generic
            },
            new TodoTask
            {
                TaskId = 3,
                Title = "Task 3",
                Type = TaskType.Generic
            },
            new TodoTask
            {
                TaskId = 4,
                Title = "Task 4",
                Type = TaskType.Generic
            }
        };

        public TodoTask AddTask(TodoTask task)
        {
            task.TaskId = _tasks.Count + 1;
            _tasks.Add(task);
            return task;
        }

        public TodoTask GetTaskById(int id)
        {
            return _tasks.SingleOrDefault(task => task.TaskId == id);
        }

        public List<TodoTask> GetTasks()
        {
            return _tasks;
        }

        public int GetTasksTotalCount()
        {
            return _tasks.Count;
        }
    }
}
