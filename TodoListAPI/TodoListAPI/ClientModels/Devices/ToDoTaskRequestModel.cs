using System.ComponentModel.DataAnnotations;


namespace TodoListAPI.ClientModels.Tasks
{
    public class TaskRequestModel
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DateTime DueDate { get; set; }

        [Required]
        public string bool IsCompleted { get; set; }
    }
}