using System;
using System.Collections.Generic;
using System.Linq;
using TodoListAPI.ClientModels.Tasks;
using TodoListAPI.Exceptions;
using TodoListAPI.Interfaces.Repositories;
using TodoListAPI.Interfaces.Services;
using TodoListAPI.Models;

namespace TodoListAPI.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _taskRepository;

        public TodoTaskService(ITodoTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TodoTask> GetTasks(out int totalCount)
        {
            totalCount = _taskRepository.GetTasksTotalCount();
            return _taskRepository.GetTasks();
        }

        public TodoTask GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public TodoTask AddTask(TodoTask task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                throw new BadOperationException("Task title cannot be empty.");
            }

            return _taskRepository.AddTask(task);
        }

        public TodoTask UpdateTask(int id, TaskRequestModel requestModel)
        {
            var existingTask = _taskRepository.GetTaskById(id);

            if (existingTask == null)
            {
                return null;
            }

            existingTask.Title = requestModel.Title;
            existingTask.Type = requestModel.Type.Value;

            return existingTask;
        }

        public void DeleteTask(int id)
        {
            var existingTask = _taskRepository.GetTaskById(id);

            if (existingTask != null)
            {
                _taskRepository.DeleteTask(id);
            }
        }

        public void SetTaskReminder(int id, DateTime reminderDateTime)
        {
            var existingTask = _taskRepository.GetTaskById(id);

            if (existingTask == null)
            {
                throw new BadOperationException("Task not found.");
            }

            existingTask.ReminderDateTime = reminderDateTime;
        }

        public void MarkTaskAsCompleted(int id)
        {
            var existingTask = _taskRepository.GetTaskById(id);

            if (existingTask == null)
            {
                throw new BadOperationException("Task not found.");
            }

            existingTask.IsCompleted = true;
        }
    }
}
