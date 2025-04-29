namespace Domain.Entities
{
    public class TaskEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime EventDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public User? User { get; set; }
    }
}
