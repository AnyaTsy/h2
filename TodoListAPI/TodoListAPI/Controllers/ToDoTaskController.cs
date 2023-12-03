using TodoListAPI.ClientModels.Tasks;
using TodoListAPI.Exceptions;
using TodoListAPI.Interfaces.Services;
using TodoListAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;

        public TodoListController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _todoTaskService.GetTasks(out var totalCount);

            var responseModel = new ResponseModel<TodoTask>
            {
                Data = tasks,
                TotalCount = totalCount
            };

            return Ok(responseModel);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var task = _todoTaskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TaskRequestModel requestModel)
        {
            var task = new TodoTask
            {
                Title = requestModel.Title,
                Type = requestModel.Type.Value
            };

            try
            {
                var storedTask = _todoTaskService.AddTask(task);

                return Ok(storedTask);
            }
            catch (BadOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] TaskRequestModel requestModel)
        {
            try
            {
                var updatedTask = _todoTaskService.UpdateTask(id, requestModel);

                if (updatedTask == null)
                {
                    return NotFound();
                }

                return Ok(updatedTask);
            }
            catch (BadOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _todoTaskService.DeleteTask(id);
                return Ok();
            }
            catch (BadOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("{id:int}/remind")]
        public IActionResult SetReminder(int id, [FromBody] ReminderRequestModel reminderModel)
        {
            try
            {
                _todoTaskService.SetTaskReminder(id, reminderModel.ReminderDateTime);
                return Ok();
            }
            catch (BadOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id:int}/complete")]
        public IActionResult MarkAsCompleted(int id)
        {
            try
            {
                _todoTaskService.MarkTaskAsCompleted(id);
                return Ok();
            }
            catch (BadOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
