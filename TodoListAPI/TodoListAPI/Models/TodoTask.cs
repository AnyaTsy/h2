using TodoListAPI.Models

namespace TodoListAPI.Models
{
    public class TodoTask
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public TaskType Type { get; set; }
    }
}