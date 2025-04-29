using System;

namespace Domain.Entities
{
    public class UserTask
    {
        public UserTask()
        {
            Title = string.Empty;
            Description = string.Empty;
            AppUser = null!;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsNotified { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}