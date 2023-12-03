using System.Collections.Generic;
using System.Linq;
using TodoListAPI.Database;
using TodoListAPI.Interfaces.Repositories;
using TodoListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly DbSet<TodoTask> _dbSet;
        private readonly ApplicationDbContext _dbContext;

        public TodoTaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.TodoTasks;
        }

        public TodoTask AddTask(TodoTask task)
        {
            _dbSet.Add(task);
            _dbContext.SaveChanges();

            return task;
        }

        public TodoTask GetTaskById(int id)
        {
            return _dbSet.SingleOrDefault(task => task.TaskId == id);
            /*
             * SELECT * FROM [TodoTasks]
             * WHERE [TaskId] = @id;
             */
        }

        public List<TodoTask> GetTasks()
        {
            return _dbSet.ToList();
            /*
            * SELECT * FROM [TodoTasks];
            */
        }

        public int GetTasksTotalCount()
        {
            return _dbSet.Count();
            /*
            * SELECT COUNT(1) FROM [TodoTasks];
            */
        }
    }
}
