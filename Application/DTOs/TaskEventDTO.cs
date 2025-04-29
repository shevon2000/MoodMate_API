namespace Application.DTOs
{
    public class TaskEventDTO
    {
        public int Id { get; set; } // Needed for identifying/updating tasks

        public string Title { get; set; } = string.Empty; // Task Title

        public string Description { get; set; } = string.Empty; // Details about the task

        public DateTime DueDate { get; set; } // Due date of the task

        public bool IsCompleted { get; set; } // Whether the task is done

        public string UserId { get; set; } = string.Empty; // To identify which user owns the task
    }
}
