using System;
using System.Collections.Generic;
using TodoListAPI.ClientModels.Tasks;
using TodoListAPI.Models;

namespace TodoListAPI.Interfaces.Services
{
    public interface ITodoTaskService
    {
        List<TodoTask> GetTasks(out int totalCount);

        TodoTask GetTaskById(int id);

        TodoTask AddTask(TodoTask task);

        TodoTask UpdateTask(int id, TaskRequestModel requestModel);

        void DeleteTask(int id);

        void SetTaskReminder(int id, DateTime reminderDateTime);

        void MarkTaskAsCompleted(int id);
    }
}
